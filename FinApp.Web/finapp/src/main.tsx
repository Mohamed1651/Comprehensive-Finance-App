import React from 'react'
import ReactDOM from 'react-dom/client'
import App from './App.tsx'
import './index.css'
import { msalConfig } from './services/auth/AuthConfig.ts'
import { PublicClientApplication } from '@azure/msal-browser'
import { MsalProvider } from '@azure/msal-react'
import { AuthTokenProvider } from './contexts/AuthTokenProvider.tsx'

const msalInstance = new PublicClientApplication(msalConfig)   

await msalInstance.initialize();
ReactDOM.createRoot(document.getElementById('root')!).render(
    <React.StrictMode>
        <MsalProvider instance={msalInstance}>
            <AuthTokenProvider>
                <App />
            </AuthTokenProvider>
        </MsalProvider>
  </React.StrictMode>
)
