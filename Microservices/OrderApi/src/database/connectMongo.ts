import mongoose from "mongoose";

export default async function connectMongo() {
  await mongoose
    .connect("mongodb://0.0.0.0:27017/aspect", {})
    .then(() => {
      console.log(`Connected to mongodb`);
    })
    .catch((err) => {
      console.log(`Error ${err}`);
    });
}
