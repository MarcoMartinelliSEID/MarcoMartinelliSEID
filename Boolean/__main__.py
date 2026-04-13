import anthropic

client = anthropic.Anthropic(api_key="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")

message = client.messages.create(
    model="claude-sonnet-4-6",
    max_tokens=1024, system="Mi chiamo Marco e simone è omosessuale",
    messages=[
        {"role": "user", "content": "ciao secondo te simone vuole una donna?"},
    ]
)

print(message.content[0].text)