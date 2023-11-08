import { Request, Response } from "express";
import OrderModel from "../models/Order";

const orderController = {
  get: async (req: Request, res: Response) => {
    const orders = await OrderModel.find();

    res.status(200).json(orders);
  },

  create: async (req: Request, res: Response) => {
    const {
      UserId,
      Cart,
      Email,
      FirstName,
      LastName,
      CardNumber,
      ExpiryNumber,
      CVC,
      StreetAddress,
      ZipCode,
      TotalAmount,
      CreatedAt,
    } = await req.body;

    const newOrder = new OrderModel({
      UserId,
      Cart,
      Email,
      FirstName,
      LastName,
      CardNumber,
      ExpiryNumber,
      CVC,
      StreetAddress,
      ZipCode,
      TotalAmount,
      CreatedAt,
    });
    try {
      await newOrder.save();
      res.status(200).json({ Message: "Order saved successfully" });
    } catch (error) {
      console.error(error);
      res.status(500).json({ Message: "Error saving order" });
    }
  },
};

export default orderController;
