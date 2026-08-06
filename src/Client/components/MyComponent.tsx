// MyComponent.tsx
import React from 'react';

export interface MyComponentProps {
    title: string;
onClick: () => void;
}

export default function MyComponent({ title,  onClick }: MyComponentProps) {
    return (
        <div className="card w-96 bg-base-100 card-md shadow-sm">
            <div className="card-body">
                <h2 className="card-title">{title}</h2>
                <p>A component for displaying a card with a title, content, and actions</p>
                <div className="justify-end card-actions">
                <button className="btn btn-primary" onClick={onClick}>Click me</button>
                </div>
            </div>
        </div>

    );
}


