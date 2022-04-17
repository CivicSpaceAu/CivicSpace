export function fetchNodes() {
    return new Promise<{ }>((resolve) =>
        setTimeout(() => resolve({ }), 500)
    );
}

export function fetchNode() {
    return new Promise<{}>((resolve) =>
        setTimeout(() => resolve({}), 500)
    );
}
