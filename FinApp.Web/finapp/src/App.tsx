import { FC } from 'react'
import './App.css'
import { Route } from './interfaces/Route'
import Home from './pages/Home'
import Router from './components/routing/Router'
import Link from './components/routing/Link'
import Contact from './pages/Contact'
import Login from './pages/Login'
import Toolbar from './components/Toolbar'

const routes: Route[] = [
    { path: '/', component: Home },
    { path: '/contact', component: Contact },
    { path: '/login', component: Login }
]

const App: FC = () => {
    return (
        <>
            <nav className="bg-gray-800">
                <div className="mx-auto max-w-7xl px-2 sm:px-6 lg:px-8">
                    <div className="relative flex h-16 items-center justify-between">
                        <div className="flex flex-1 items-center justify-center sm:items-stretch">
                            <div className="flex flex-shrink-0 items-center">
                                <img className="h-8 w-auto" src="https://tailwindui.com/img/logos/mark.svg?color=indigo&shade=500" alt="Your Company" />
                            </div>
                            <div className="hidden sm:ml-6 sm:block">
                                <div className="flex space-x-4">
                                    <Link to="/">Home</Link>
                                    <Link to="/contact">Contact</Link>
                                    <Link to="/login">Login</Link>                                   
                                </div>
                            </div>
                        </div>
                        <div className="items-right">
                            <Toolbar />
                        </div>
                    </div>
                </div>
            </nav>
            <Router routes={routes}></Router>
        </>
    )
}

export default App
