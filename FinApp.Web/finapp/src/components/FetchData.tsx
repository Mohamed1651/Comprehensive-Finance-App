/* eslint-disable @typescript-eslint/no-explicit-any */
// src/components/FetchData.tsx
import React, { useEffect, useState } from "react";
import { useMsal } from "@azure/msal-react";
import { loginRequest } from "../authConfig"; // contains scopes

const FetchData: React.FC = () => {
    const { instance, accounts } = useMsal();
    const [data, setData] = useState<string | null>(null);
    const [error, setError] = useState<string | null>(null);

    useEffect(() => {
        const fetchData = async () => {
            try {
                const account = accounts[0];
                console.log("Attempting acquireTokenSilent...");
                const response = await instance.acquireTokenSilent({
                    ...loginRequest,
                    account: account,
                });

                const accessToken = response.accessToken;

                const apiResponse = await fetch("https://localhost:7233/api/user/me", {
                    headers: {
                        Authorization: `Bearer ${accessToken}`,
                    },
                });

                if (!apiResponse.ok) {
                    throw new Error(`Error: ${apiResponse.status}`);
                }

                const result = await apiResponse.text(); // or .json() if JSON
                setData(result);
            } catch (err: any) {
                setError(err.message);
            }
        };

        fetchData();
    }, [instance, accounts]);

    if (error) return <div>Error: {error}</div>;
    if (!data) return <div>Loading...</div>;

    return <div>API Response: {data}</div>;
};

export default FetchData;
