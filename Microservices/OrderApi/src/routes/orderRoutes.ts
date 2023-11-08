import { Router } from "express";
import orderController from "../controllers/orderController";

const orderRouter = Router();

orderRouter.post("/api/order", orderController.create);
orderRouter.get("/api/order", orderController.get);

export default orderRouter;
