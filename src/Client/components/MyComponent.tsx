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
                <p>A card component has a figure, a body part, and inside body there are title and actions parts</p>
                <div className="justify-end card-actions">
                <button className="btn btn-primary" onClick={onClick}>Click me</button>
                </div>
            </div>
        </div>

    );
}


