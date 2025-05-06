export const msalConfig = {
    auth: {
        clientId: "c0823f26-d311-44cc-8884-272d8e07d0b1",
        authority: "https://login.microsoftonline.com/4eb6125c-ba6d-4dd7-a8b1-66cb43721ced/v2.0",
        redirectUri: "https://localhost:5173",
    },
    cache: {
        cacheLocation: "localStorage",
        storeAuthStateInCookie: false,
    },
};

export const loginRequest = {
    scopes: ["api://c0823f26-d311-44cc-8884-272d8e07d0b1/access_as_user"]
};