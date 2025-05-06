import { PublicClientApplication, AccountInfo } from "@azure/msal-browser";
import { loginRequest } from "./AuthConfig";

export const getAccessToken = async (instance: PublicClientApplication, account: AccountInfo) : Promise<string> => {
    const response = await instance.acquireTokenSilent({
        ...loginRequest,
        account
    });

    return response.accessToken;
}