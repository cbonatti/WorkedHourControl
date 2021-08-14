import { Injectable } from '@angular/core';

@Injectable()
export class LocalStorageService {
     read(path: string): any {
            // if not in local storage, the string "undefined" is returned
            let text: string = localStorage.getItem(path);
            if (text === null || typeof text === 'undefined' || text === 'undefined') {
                return null;
            }
            else {
                return text;
            }
        }

        readObject<T>(path): T {
            let text: any = this.read(path);
            let data: T;
            try {
                data = <T>JSON.parse(text);
            } catch (error) {
                data = null;
            }

            return data;
        }

        write(path: string, text: string): void {
            localStorage.setItem(path, text);
        }

        writeObject(path: string, data: any): void {
            let text: string = JSON.stringify(data);
            this.write(path, text);
        }

        remove(path: string): void {
            localStorage.removeItem(path);
        }

        clear(): void {
            localStorage.clear();
        }
}