class CachE<T> {
  private storage: Map<string, { value: T; expires: number }> = new Map();
  
  constructor() {}

  add(key: string, value: T, ttl: number): void {
    const expires = Date.now() + ttl;
    this.storage.set(key, { value, expires });
  }

  get(key: string): T | null {
    const entry = this.storage.get(key);
    if (!entry) return null;
    if (Date.now() > entry.expires) {
      this.storage.delete(key);
      return null;
    }
    return entry.value;
  }

  clearExpired(): void {
    this.storage.forEach((entry, key) => {
      if (Date.now() > entry.expires) {
        this.storage.delete(key);
      }
    });
  }
}

const cache = new CachE<number>();

cache.add("price", 100, 3000);
console.log(cache.get("price"));

setTimeout(() => console.log(cache.get("price")), 4000);