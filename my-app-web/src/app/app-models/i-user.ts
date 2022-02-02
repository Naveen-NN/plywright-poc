import { IAddress } from "./i-address";
export interface IUser{
    id: number;  
    name: string;  
    email: string;
    username: string;
    address: IAddress
}