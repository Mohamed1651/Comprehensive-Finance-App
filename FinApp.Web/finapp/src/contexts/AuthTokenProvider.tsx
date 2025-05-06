import React, { createContext, useState, useContext, useEffect } from "react"
import { AuthTokenContextType } from "../types/AuthTokenContextType";
import { useMsal } from "@azure/msal-react";
import { PublicClientApplication } from "@azure/msal-browser";
import { loginRequest } from "../services/auth/AuthConfig";

const AuthTokenContext = createContext<AuthTokenContextType | undefined>(undefined);

export const AuthTokenProvider: React.FC<{ children: React.ReactNode }> = ({ children }) => {
    const { instance, accounts } = useMsal();
    const [accessToken, setAccessToken] = useState<string | null>(null);

    const acquireToken = async () => {
        if (!accounts || accounts.length === 0 || !(instance instanceof PublicClientApplication)) return;

        try {
            const account = accounts[0];
            const response = await instance.acquireTokenSilent({
                ...loginRequest,
                account,
            });
            setAccessToken(response.accessToken);
            console.log("response", response);  
        } catch (error) {
            console.error("Silent token acquisition failed", error);
            setAccessToken(null);
        }
    };

    useEffect(() => {
        acquireToken(); // automatically fetch on mount
    }, [accounts]);

    return (
        <AuthTokenContext.Provider
            value={{
                accessToken,
                refreshToken: acquireToken,
            }}
        >
            {children}
        </AuthTokenContext.Provider>
    );
}

export const useAuthToken = () => {
    const context = useContext(AuthTokenContext);
    if (!context) throw new Error("useAuthToken must be used within AuthTokenProvider");
    return context;
};