import { FC } from 'react'
import './App.css'
import { Route } from './interfaces/Route'
import Home from './pages/Home'
import Router from './components/routing/Router'
import Link from './components/routing/Link'
import About from './pages/About'

const routes: Route[] = [
    { path: '/', component: Home },
    { path: '/about', component: About }
]

const App: FC = () => {
    return (
        <>
            <div>
                <nav>
                    <ul>
                        <li>
                            <Link to="/">Home</Link>
                        </li>
                        <li>
                            <Link to="/about">About</Link>
                        </li>
                    </ul>
                </nav>
                <Router routes={routes}></Router>
            </div>
            <h1 className="text-3xl font-bold underline">
                Hello world!
            </h1>
        </>
    )
}

export default App
