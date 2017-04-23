import { Floor } from '../floor/Floor';

export class Dormitory {

    Id: number;
    Description: string;
    Address: string;
    Number: number;
    ComendantId: number;
    Floors: Floor[];
}