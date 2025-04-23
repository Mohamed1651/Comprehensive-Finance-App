import React from "react";
import Toolbar from "./components/Toolbar";
import Home from "./pages/Home";
import Router from "./components/routing/Router";
import { useMsal } from "@azure/msal-react";
import FetchData from "./components/FetchData";
import { loginRequest } from "./authConfig"
const routes = [
    { path: '/', component: Home },
];

const LoginButton: React.FC = () => {
    const { instance } = useMsal();

    const handleLogin = () => {
        instance.loginRedirect(loginRequest);
    };

    return <button onClick={handleLogin}>Login with Azure</button>;
};

export const LogoutButton: React.FC = () => {
    const { instance, accounts } = useMsal();

    const handleLogout = () => {
        // Choose redirect or popup. Redirect is simplest:
        instance.logoutRedirect({
            account: accounts[0],           // specify which account to sign out
            postLogoutRedirectUri: "/",     // where to go after logout
        });
    };

    return <button onClick={handleLogout}>Logout</button>;
};

const App: React.FC = () => {
    return (
        <div>
            <Toolbar />
            <main>
                <LoginButton />
                <LogoutButton />
                <h1>Welcome to the App!</h1>
                <FetchData />
                <Router routes={routes} />
            </main>
        </div>
    );
};

export default App;
