using System;
using System.Runtime.CompilerServices;
using Cysharp.Threading.Tasks;

// Token: 0x020034ED RID: 13549
[NullableContext(1)]
[Nullable(0)]
[UnitTest]
public class LogTest : UnitTestBase
{
	// Token: 0x170026EE RID: 9966
	// (get) Token: 0x0601CA30 RID: 117296 RVA: 0x00896EA2 File Offset: 0x008950A2
	public override string Name
	{
		get
		{
			return "LogTest";
		}
	}

	// Token: 0x0601CA31 RID: 117297 RVA: 0x00896EAC File Offset: 0x008950AC
	[NullableContext(0)]
	public unsafe override UniTask<bool> Run([Nullable(1)] params object[] args)
	{
		LogTest.Person item = new LogTest.Person
		{
			Name = "John",
			Age = 20
		};
		string message = "这是Debug的Log";
		ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("Person", item);
		base.Debug(message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
		string message2 = "这是Info的Log";
		ValueTuple<string, object> valueTuple2 = new ValueTuple<string, object>("参数1", 1);
		base.Info(message2, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple2));
		string message3 = "这是Warn的Log";
		<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray2<ValueTuple<string, object>>);
		*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("参数1", 1);
		*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("参数2", "abc");
		base.Warn(message3, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 2));
		string message4 = "这是Error的Log";
		<>y__InlineArray3<ValueTuple<string, object>> <>y__InlineArray2 = default(<>y__InlineArray3<ValueTuple<string, object>>);
		*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray2, 0) = new ValueTuple<string, object>("参数1", 1);
		*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray2, 1) = new ValueTuple<string, object>("参数2", "abc");
		*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray2, 2) = new ValueTuple<string, object>("参数3", 0.1f);
		base.Error(message4, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray2, 3));
		return UniTask.FromResult<bool>(true);
	}

	// Token: 0x020096A1 RID: 38561
	[Nullable(0)]
	public class Person
	{
		// Token: 0x1700A902 RID: 43266
		// (get) Token: 0x0604A587 RID: 304519 RVA: 0x0142DCB9 File Offset: 0x0142BEB9
		// (set) Token: 0x0604A588 RID: 304520 RVA: 0x0142DCC1 File Offset: 0x0142BEC1
		public string Name { get; set; }

		// Token: 0x1700A903 RID: 43267
		// (get) Token: 0x0604A589 RID: 304521 RVA: 0x0142DCCA File Offset: 0x0142BECA
		// (set) Token: 0x0604A58A RID: 304522 RVA: 0x0142DCD2 File Offset: 0x0142BED2
		public int Age { get; set; }

		// Token: 0x0604A58B RID: 304523 RVA: 0x0142DCDC File Offset: 0x0142BEDC
		public override string ToString()
		{
			DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(13, 2);
			defaultInterpolatedStringHandler.AppendLiteral("Name: ");
			defaultInterpolatedStringHandler.AppendFormatted(this.Name);
			defaultInterpolatedStringHandler.AppendLiteral(", Age: ");
			defaultInterpolatedStringHandler.AppendFormatted<int>(this.Age);
			return defaultInterpolatedStringHandler.ToStringAndClear();
		}
	}
}
