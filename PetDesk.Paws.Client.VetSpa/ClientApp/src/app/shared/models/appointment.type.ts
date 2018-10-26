import { User } from "./user.type";
import { Animal } from "./animal.type";


export class Appointment
{
    appointmentId: number;
    appointmentType: string;
    createdDateTime: Date;
    requestedDateTime: Date;
    user: User;
    animal: Animal;
}
