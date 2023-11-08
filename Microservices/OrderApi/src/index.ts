import express, { Express } from "express";
import cors from "cors";
import orderRouter from "./routes/orderRoutes";
import connectMongo from "./database/connectMongo";

connectMongo();
const app = express();

app.use(cors());
app.use(express.json());

app.use("/", orderRouter);

app.listen(3001, () => {
  console.log(`App is listening in port 3001`);
});
