import React, { FC } from 'react';
import { LinkProps } from './interfaces/LinkProps'

const Link: FC<LinkProps> = ({ to, children }) => {
    const handleClick = (event: React.MouseEvent<HTMLAnchorElement, MouseEvent>) => {
        event.preventDefault();
        window.history.pushState({}, '', to);
        const navEvent = new PopStateEvent('popstate');
        window.dispatchEvent(navEvent);
    }

    return (
        <a href={to} onClick={handleClick}>
            {children}
        </a>
    )
}

export default Link;