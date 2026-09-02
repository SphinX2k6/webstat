using System;
using System.Buffers;
using System.Runtime.CompilerServices;
using System.Runtime.Serialization;
using Aki.Protocol;
using Google.Protobuf;

namespace CSharpScript.Core.Net
{
	// Token: 0x0200711E RID: 28958
	public readonly struct MessageSerializationBuffer : IDisposable
	{
		// Token: 0x1700A5F8 RID: 42488
		// (get) Token: 0x06046261 RID: 287329 RVA: 0x0126C620 File Offset: 0x0126A820
		public Span<byte> MessageSpan
		{
			get
			{
				return new Span<byte>(this.Buffer, 0, this.MessageSize);
			}
		}

		// Token: 0x1700A5F9 RID: 42489
		// (get) Token: 0x06046262 RID: 287330 RVA: 0x0126C634 File Offset: 0x0126A834
		public int Length
		{
			get
			{
				return this.MessageSize;
			}
		}

		// Token: 0x06046263 RID: 287331 RVA: 0x0126C63C File Offset: 0x0126A83C
		private MessageSerializationBuffer(int messageSize)
		{
			this.Buffer = Array.Empty<byte>();
			this.MessageSize = 0;
			this.Buffer = ArrayPool<byte>.Shared.Rent(messageSize);
			this.MessageSize = messageSize;
		}

		// Token: 0x06046264 RID: 287332 RVA: 0x0126C668 File Offset: 0x0126A868
		public void Dispose()
		{
			if (this.Buffer != null)
			{
				ArrayPool<byte>.Shared.Return(this.Buffer, false);
			}
		}

		// Token: 0x06046265 RID: 287333 RVA: 0x0126C684 File Offset: 0x0126A884
		[NullableContext(1)]
		public unsafe static MessageSerializationBuffer GetBuffer(EMessageId msgId, IMessage message)
		{
			int messageSize = message.CalculateSize();
			MessageSerializationBuffer messageSerializationBuffer = new MessageSerializationBuffer(messageSize);
			MessageSerializationBuffer result;
			try
			{
				message.WriteTo(messageSerializationBuffer.MessageSpan);
				result = messageSerializationBuffer;
			}
			catch (Exception ex)
			{
				messageSerializationBuffer.Dispose();
				Log instance = Singleton<Log>.Instance;
				ELogModule module = ELogModule.Net;
				ELogAuthor author = ELogAuthor.LRX;
				string message2 = "消息写入失败!";
				<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray2<ValueTuple<string, object>>);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("ex:", ex);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("msgId:", msgId);
				instance.Error(module, author, message2, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 2));
				DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(9, 1);
				defaultInterpolatedStringHandler.AppendLiteral("消息 ");
				defaultInterpolatedStringHandler.AppendFormatted<EMessageId>(msgId);
				defaultInterpolatedStringHandler.AppendLiteral(" 序列化失败");
				throw new SerializationException(defaultInterpolatedStringHandler.ToStringAndClear(), ex);
			}
			return result;
		}

		// Token: 0x04027568 RID: 161128
		[Nullable(1)]
		private readonly byte[] Buffer;

		// Token: 0x04027569 RID: 161129
		private readonly int MessageSize;
	}
}
