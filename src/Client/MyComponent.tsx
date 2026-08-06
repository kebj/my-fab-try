// MyComponent.tsx
import React from 'react';

export interface MyComponentProps {
    title: string;
    count: number;
    onReset: () => void;
}

export default function MyComponent({ title, count, onReset }: MyComponentProps) {
    return (
        <div>
            <h2>{title}</h2>
            <p>Count: {count}</p>
            <button onClick={onReset}>Reset</button>
        </div>
    );
}