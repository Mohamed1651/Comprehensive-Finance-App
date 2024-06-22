import { useState, useEffect, FC } from 'react';
import { RouterProps } from '../../interfaces/RouterProps';

const Router: FC<RouterProps> = ({ routes }) => {
    const [currentPath, setCurrentPath] = useState<string>(window.location.pathname);

    useEffect(() => {
        const onLocationChange = () => {
            setCurrentPath(window.location.pathname);
        };

        window.addEventListener('popstate', onLocationChange);

        return () => {
            window.removeEventListener('popstate', onLocationChange);
        };
    }, []);

    const RouteComponent = routes.find(route => route.path === currentPath)?.component || null;
    return RouteComponent ? <RouteComponent /> : <div>404 Not Found</div>;
}

export default Router;