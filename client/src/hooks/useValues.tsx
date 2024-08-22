import { useContext } from 'react';
import ValuesContext, { ValuesContextType } from '../context/ValuesProvider';

const useValues = () => {
    return useContext(ValuesContext) as ValuesContextType;
};

export default useValues;