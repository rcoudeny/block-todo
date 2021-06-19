export class TodoItem {
    private id: string | undefined;
    private title: string | undefined;
    private description: string | undefined;
    private duration: string | undefined;
    private startTime: Date | undefined;
    private subtodos: string | undefined;

    public get $id(): string | undefined {
        return this.id;
    }

    public set $id(value: string | undefined) {
        this.id = value;
    }

    public get $title(): string | undefined {
        return this.title;
    }

    public set $title(value: string | undefined) {
        this.title = value;
    }

    public get $description(): string | undefined {
        return this.description;
    }

    public set $description(value: string | undefined) {
        this.description = value;
    }

    public get $duration(): string | undefined {
        return this.duration;
    }

    public set $duration(value: string | undefined) {
        this.duration = value;
    }

    public get $startTime(): Date | undefined {
        return this.startTime;
    }

    public set $startTime(value: Date | undefined) {
        this.startTime = value;
    }

    public get $subtodos(): string | undefined {
        return this.subtodos;
    }

    public set $subtodos(value: string | undefined) {
        this.subtodos = value;
    }
}
