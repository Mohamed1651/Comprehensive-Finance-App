import { useEffect, useState } from "react";
import { useAuthToken } from "../contexts/AuthTokenProvider";
import { fetchUsers } from "../services/user/UserService";
import User from "../types/User";

const UserList: React.FC = () => {
    const { accessToken, refreshToken } = useAuthToken();
    const [data, setData] = useState<any>(null);
    const [error, setError] = useState<string | null>(null);

    useEffect(() => {
        const fetchData = async () => {
                if (!accessToken) {
                    await refreshToken();
                    return;
                }
                try {
                    const result = await fetchUsers(accessToken); 
                    setData(result);
                } catch (err: any){
                    setError(err.message);
                }        
            };
        fetchData();
    }, [accessToken]);

    if (error) return <div>Error: {error}</div>;
    if (!data) return <div>Loading...</div>;
    return (
        <div>
            <ul style={{ listStyleType: 'disc', paddingLeft: '20px' }}>
            {data.map((item: User) => (
                <li>Name: {item.name} Email: {item.email}</li>
            ))}
          </ul>
        </div>
      );

}

export default UserList;