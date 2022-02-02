import { IGeo } from "./i-geo";

export interface IAddress{
    street: string; 
    suite: string; 
    city:string;
    zipcode:string; 
    geo: IGeo
}