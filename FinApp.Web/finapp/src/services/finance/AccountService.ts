import Account from "../../types/Account";
import { fetchWithAuth } from "../../utils/fetchWithAuth";

export const createAccount = async (data: Account) : Promise<Account> => {
    try {
        const response = await fetchWithAuth("https://localhost:7233/api/account/create-account", {
            method: "POST",
            headers: {
            "Content-Type": "application/json",
            },
            body: JSON.stringify(data),
        });
        if (!response.ok) {
            throw new Error(`Error: ${response.status}`);
        }
    }
    catch (e){
       throw e
    }
    return data;
}