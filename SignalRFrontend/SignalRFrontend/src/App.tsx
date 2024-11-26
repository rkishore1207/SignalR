/* eslint-disable @typescript-eslint/no-explicit-any */
import { useEffect, useState } from "react";
import * as SignalR from "@microsoft/signalr"
import axios from "axios";

function App() {

  const [count, setCount] = useState<number>(0);

  useEffect(() => {

    const connection = new SignalR.HubConnectionBuilder().withUrl("https://localhost:7030/signalRHub").build();

    // connection.on("updateCount",(value : number) => {
    //   setCount(value);
    // });

    const startSuccess = () => {
      console.log("Connection Established");
    }

    const startFailed = () => {
      console.log("Connection Failed");
    }

    connection.start().then(startSuccess, startFailed);

  },[]);

  const apiService = async (newCount : number) => {    
    const result = await axios.get("https://localhost:7030/api/signalRController/count",{
      params:{
        value : newCount
      }
    });
    return result.data;
  }

  const incrementCount = () => {
    const newCount = count + 1;
    apiService(newCount).then((result : any)=>{
      console.log(result);
      //setCount(result);
    }).catch((error : any) => console.log(error));
  }

  return (
    <>
      <button onClick={incrementCount}>Click</button>
      <p>{count}</p>
    </>
  )
}

export default App
