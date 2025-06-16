import React, { ChangeEvent, FormEvent, useState } from 'react';
import Account from '../types/Account';
import { createAccount } from '../services/finance/AccountService';

const Form : React.FC = () => {
const [showForm, setShowForm] = useState(false);
const [formData, setFormData] = useState<Account>({
    id: 0,
    name: '',
    accountType: 'DebitCard',
    balance: 0.00,
    userId: 0
  });

const handleChange = (e : ChangeEvent<HTMLInputElement | HTMLSelectElement>) => {
setFormData(prev => ({
    ...prev,
      [e.target.name]: e.target.value,
    }));
  };

const handleSubmit = (e : FormEvent<HTMLFormElement>) => {
    e.preventDefault();
    console.log('Submitted data:', formData);
    // Reset or handle the form submission here
    createAccount(formData);
    setShowForm(false);
    setFormData({id: 0, name: '', accountType: 'DebitCard', balance: 0.00, userId: 0});
};

return (
  <div className = "max-w-md mx-auto p-4 border rounded-lg shadow" >
      {
    !showForm ? (
        <button
          onClick ={ () => setShowForm(true)}
          className = "bg-blue-600 text-white px-4 py-2 rounded hover:bg-blue-700 transition">
           Show Form
        </button>
      ) : (
        <form onSubmit ={ handleSubmit} 
          className = "space-y-4" >
          <div>
            <label className = "block text-sm font-medium text-gray-700">Name</label>
            <input
              type = "text"
              name = "name"
              value={ formData.name}
              onChange ={ handleChange}
              className = "mt-1 block w-full border border-gray-300 rounded px-3 py-2"
              required
            />
          </div>
          <div>
            <label className="block text-sm font-medium text-gray-700">Account Type</label>
            <select
              name="accountType"
              value={formData.accountType}
              onChange={handleChange}
              className="mt-1 block w-full border border-gray-300 rounded px-3 py-2"
              required
            >
              <option value="">Select an account type</option>
              <option value="CreditCard">Credit Card</option>
              <option value="DebitCard">Debit Card</option>
            </select>
          </div>
          <div>
            <label className="block text-sm font-medium text-gray-700">Balance</label>
            <input
              type="number"
              name="balance"
              step="0.01"  // allows decimal values
              value={formData.balance}
              onChange={handleChange}
              className="mt-1 block w-full border border-gray-300 rounded px-3 py-2"
              required
            />
          </div>
          <div className = "flex gap-2">
            <button
              type = "submit"
              className = "bg-green-600 text-white px-4 py-2 rounded hover:bg-green-700 transition"
            >
              Submit
            </button>
            <button
              type = "button"
              onClick ={ () => setShowForm(false)}
              className = "bg-gray-300 px-4 py-2 rounded hover:bg-gray-400 transition"
            >
              Cancel
            </button>
          </div>
        </form>
      )}
    </div>
  );
};

export default Form;