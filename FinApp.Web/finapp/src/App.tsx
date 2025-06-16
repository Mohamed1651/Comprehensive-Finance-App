import React from "react";
import Toolbar from "./components/Toolbar";
import Home from "./pages/Home";
import Router from "./components/routing/Router";
import { useMsal } from "@azure/msal-react";
import UserDetails from "./components/UserDetails";
import { loginRequest } from "./services/auth/AuthConfig"
import UserList from "./components/UserList";
import Form from "./components/Form";
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
        instance.logoutRedirect({
            account: accounts[0],           
            postLogoutRedirectUri: "/",     
        });
    };

    return <button onClick={handleLogout}>Logout</button>;
};

const App: React.FC = () => {
    const { accounts } = useMsal();
    const isLoggedIn = accounts && accounts.length > 0;
    return (
        <div>
            <Toolbar />
            <main>
                <LoginButton />
                <LogoutButton />
                <h1>Welcome to the App!</h1>
                <UserDetails />
                <UserList />
                {isLoggedIn && <Form />}
                <Router routes={routes} />
            </main>
        </div>
    );
};

export default App;
