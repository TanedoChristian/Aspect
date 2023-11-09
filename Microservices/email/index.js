require("dotenv").config();
const amqp = require("amqplib");
const nodemailer = require("nodemailer");

// Create RabbitMQ connection
const rabbitMQUrl = process.env.RABBITMQ_URL || "amqp://localhost";
const queueName = "emailQueue";

async function consumeMessage() {
  const connection = await amqp.connect(rabbitMQUrl);
  const channel = await connection.createChannel();

  await channel.assertQueue(queueName, { durable: true });

  channel.consume(queueName, async (msg) => {
    const emailContent = JSON.parse(msg.content.toString());
    console.log(`Received message: ${JSON.stringify(emailContent)}`);
    const transporter = nodemailer.createTransport({
      service: "gmail",
      auth: {
        user: "ctanedo@fullscale.io",
        pass: process.env.EMAIL_PASS,
      },
    });

    const mailOptions = {
      from: "ctanedo@fullscale.io",
      to: emailContent.to,
      subject: "New User",
      text: "Thank you for choosing Aspect",
    };

    try {
      const info = await transporter.sendMail(mailOptions);
      console.log("Email sent: " + info.response);
    } catch (error) {
      console.error("Error sending email:", error);
    }
    channel.ack(msg);
  });
}

consumeMessage();
