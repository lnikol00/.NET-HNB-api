import React, { useEffect, useRef, useState } from 'react'

import { Datepicker } from "flowbite-react";
import useValues from '../hooks/useValues';
import { useNavigate } from 'react-router-dom';

function Input() {

    const [fromDate, setFromDate] = useState<string>("")
    const [toDate, setToDate] = useState<string>("")

    const { getValues, errMsg, setErrMsg } = useValues();
    const navigate = useNavigate();

    const errRef = useRef<null | HTMLParagraphElement>(null)

    useEffect(() => {
        setErrMsg('');
    }, [fromDate, toDate])

    const handleSubmit = async (e: React.FormEvent<HTMLFormElement>) => {
        e.preventDefault();
        await getValues(fromDate, toDate);
        navigate("/values");
    };

    return (
        <div className='absolute top-[50%] left-[50%] translate-y-[-50%] translate-x-[-50%]  flex justify-center items-center flex-col'>
            <h1 className="text-[30px] py-5">HNB Currency Calculator</h1>
            <form onSubmit={handleSubmit} className=' flex justify-center items-center flex-col gap-10'>
                <div className='flex justify-center items-center gap-10'>
                    <Datepicker inline title="From Date" value={fromDate} onChange={(e) => setFromDate(e.target.value)} />
                    <Datepicker inline title="To Date" value={toDate} onChange={(e) => setToDate(e.target.value)} />
                </div>

                <button>
                    Calculate
                </button>
            </form>
        </div>
    )
}

export default Input
