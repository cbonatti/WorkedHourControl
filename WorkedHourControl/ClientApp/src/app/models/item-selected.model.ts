export class ItemSelectedModel {
    id: number;
    name: string;
    selected: boolean;

    constructor(id, name, selected) {
        this.id = id;
        this.name = name;
        this.selected = selected;
    }
}