import { FC } from 'react';
import Link from './routing/Link';

const Toolbar: FC = () => {
    return (
        <nav>
            <Link to="/">Home</Link>
        </nav>
    )
}

export default Toolbar;