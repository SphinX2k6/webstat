using System;
using System.Runtime.CompilerServices;
using Aki.Protocol;
using Cysharp.Threading.Tasks;
using UnrealEngine;

// Token: 0x020034EB RID: 13547
[NullableContext(1)]
[Nullable(0)]
[UnitTest]
public class EventTest : UnitTestBase
{
	// Token: 0x170026EC RID: 9964
	// (get) Token: 0x0601CA24 RID: 117284 RVA: 0x00896B4A File Offset: 0x00894D4A
	public override string Name
	{
		get
		{
			return "EventTest";
		}
	}

	// Token: 0x0601CA25 RID: 117285 RVA: 0x00896B51 File Offset: 0x00894D51
	[NullableContext(0)]
	public override UniTask<bool> Run([Nullable(1)] params object[] args)
	{
		return UniTask.FromResult<bool>(true);
	}

	// Token: 0x0601CA26 RID: 117286 RVA: 0x00896B5C File Offset: 0x00894D5C
	private void OnEvent1(EAddEntityType addType, EntityHandle handle, AActor actor)
	{
		base.Info("[测试用例] OnEvent1", default(ReadOnlySpan<ValueTuple<string, object>>));
	}

	// Token: 0x0601CA27 RID: 117287 RVA: 0x00896B80 File Offset: 0x00894D80
	private void OnEvent2(int p1)
	{
		string message = "OnEvent2";
		ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("P1", p1);
		base.Info(message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
	}

	// Token: 0x0601CA28 RID: 117288 RVA: 0x00896BB4 File Offset: 0x00894DB4
	private unsafe void OnEvent3(int p1, string p2)
	{
		string message = " OnEvent3";
		<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray2<ValueTuple<string, object>>);
		*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("P1", p1);
		*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("P2", p2);
		base.Info(message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 2));
	}

	// Token: 0x0601CA29 RID: 117289 RVA: 0x00896C14 File Offset: 0x00894E14
	private unsafe void OnEvent4(int p1, string p2, float p3)
	{
		string message = "OnEvent4";
		<>y__InlineArray3<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray3<ValueTuple<string, object>>);
		*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("P1", p1);
		*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("P2", p2);
		*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 2) = new ValueTuple<string, object>("P3", p3);
		base.Info(message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 3));
	}

	// Token: 0x0601CA2A RID: 117290 RVA: 0x00896C90 File Offset: 0x00894E90
	private unsafe void OnEvent5(int p1, string p2, float p3, DateTime p4)
	{
		string message = "OnEvent5";
		<>y__InlineArray4<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray4<ValueTuple<string, object>>);
		*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray4<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("P1", p1);
		*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray4<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("P2", p2);
		*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray4<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 2) = new ValueTuple<string, object>("P3", p3);
		*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray4<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 3) = new ValueTuple<string, object>("P4", p4);
		base.Info(message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray4<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 4));
	}

	// Token: 0x0601CA2B RID: 117291 RVA: 0x00896D28 File Offset: 0x00894F28
	private unsafe void OnEvent6(int p1, string p2, float p3, DateTime p4, bool p5)
	{
		string message = "OnEvent5";
		<>y__InlineArray5<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray5<ValueTuple<string, object>>);
		*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray5<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("P1", p1);
		*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray5<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("P2", p2);
		*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray5<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 2) = new ValueTuple<string, object>("P3", p3);
		*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray5<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 3) = new ValueTuple<string, object>("P4", p4);
		*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray5<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 4) = new ValueTuple<string, object>("P5", p5);
		base.Info(message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray5<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 5));
	}
}
