import { Date } from "mongoose";

export default interface IOrder {
  UserId: number;
  Cart: any[];
  Email: string;
  FirstName: string;
  LastName: string;
  CardNumber: string;
  ExpiryNumber: string;
  CVC: string;
  StreetAddress: string;
  ZipCode: string;
  TotalAmount: number;
  CreatedAt: Date;
}
