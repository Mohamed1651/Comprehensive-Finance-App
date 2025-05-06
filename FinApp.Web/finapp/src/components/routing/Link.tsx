import React, { FC } from 'react';
import { LinkProps } from '../../types/LinkProps'

const Link: FC<LinkProps> = ({ to, children }) => {
    const handleClick = (event: React.MouseEvent<HTMLAnchorElement, MouseEvent>) => {
        event.preventDefault();
        window.history.pushState({}, '', to);
        const navEvent = new PopStateEvent('popstate');
        window.dispatchEvent(navEvent);
    }

    return (
        <a className="rounded-md px-3 py-2 text-sm font-medium text-gray-300 hover:bg-gray-700 hover:text-white" href={to} onClick={handleClick}>
            {children}
        </a>
    )
}

export default Link;