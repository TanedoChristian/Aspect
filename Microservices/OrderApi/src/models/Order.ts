import mongoose, { Schema } from "mongoose";
import IOrder from "../interfaces/IOrder";

const orderSchema = new Schema<IOrder>({
  UserId: { type: Number, required: true },
  Cart: { type: [], required: true }, // Adjust the type based on the structure of Cart data
  Email: { type: String, required: true },
  FirstName: { type: String, required: true },
  LastName: { type: String, required: true },
  CardNumber: { type: String, required: true },
  ExpiryNumber: { type: String, required: true },
  CVC: { type: String, required: true },
  StreetAddress: { type: String, required: true },
  ZipCode: { type: String, required: true },
  TotalAmount: { type: Number, required: true },
  CreatedAt: { type: Date, required: true },
});

const OrderModel = mongoose.model<IOrder>("Order", orderSchema);

export default OrderModel;
