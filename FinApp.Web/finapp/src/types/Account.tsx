type Account = {
    id: number;
    name: string;
    accountType: AccountType;
    balance: number;
    userId: 0
}

type AccountType = 'CreditCard' | 'DebitCard'

export default Account;