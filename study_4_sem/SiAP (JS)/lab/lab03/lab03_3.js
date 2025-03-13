var CachE = /** @class */ (function () {
    function CachE() {
        this.storage = new Map();
    }
    CachE.prototype.add = function (key, value, ttl) {
        var expires = Date.now() + ttl;
        this.storage.set(key, { value: value, expires: expires });
    };
    CachE.prototype.get = function (key) {
        var entry = this.storage.get(key);
        if (!entry)
            return null;
        if (Date.now() > entry.expires) {
            this.storage.delete(key);
            return null;
        }
        return entry.value;
    };
    CachE.prototype.clearExpired = function () {
        var _this = this;
        this.storage.forEach(function (entry, key) {
            if (Date.now() > entry.expires) {
                _this.storage.delete(key);
            }
        });
    };
    return CachE;
}());
var cache = new CachE();
cache.add("price", 100, 3000);
console.log(cache.get("price"));
setTimeout(function () { return console.log(cache.get("price")); }, 4000);
