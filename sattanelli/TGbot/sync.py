
import asyncio

async def foo():
    print("io 1")
    await foo2()
    print("2 ha finito e quindi te l ho detto coglione")

async def foo2():        
    print("io 2")
    await asyncio.sleep(10)

asyncio.run(foo())
