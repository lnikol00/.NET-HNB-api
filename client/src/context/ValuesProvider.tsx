import React, { createContext, useState, useRef } from 'react';
import { AxiosError } from 'axios';
import axios from '../api/axios';

interface ValueType {
    children: React.ReactNode;
}

export type ValuesContextType = {
    values: any[];
    errMsg: string;
    setErrMsg: React.Dispatch<React.SetStateAction<string>>;
    getValues: (fromDate: string, toDate: string) => Promise<void>;
};

const ValuesContext = createContext<ValuesContextType | null>(null);

export const ValuesProvider = ({ children }: ValueType) => {
    const [values, setValues] = useState<any[]>([]);
    const [errMsg, setErrMsg] = useState('');
    const errRef = useRef<HTMLParagraphElement>(null);

    const getValues = async (fromDate: string, toDate: string) => {
        try {
            const allValues = await axios.get(
                '/api/Currency', {
                params: {
                    fromDate,
                    toDate,
                },
                headers: {
                    "Content-Type": "application/json",
                    "Accept": "application/json"
                }
            }
            );
            console.log(allValues);
        } catch (error) {
            const err = error as AxiosError;
            if (!err.response) {
                setErrMsg("No server response");
            } else if (err.response?.status === 400) {
                setErrMsg("Enter both dates!");
            }
            if (errRef.current) errRef.current.focus();
        }
    };

    return (
        <ValuesContext.Provider value={{ values, getValues, errMsg, setErrMsg }}>
            {children}
        </ValuesContext.Provider>
    );
};

export default ValuesContext;