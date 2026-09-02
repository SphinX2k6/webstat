using System;
using System.Runtime.CompilerServices;
using CSharpScript.Core.Framework;
using CSharpScript.Game.Manager;
using Cysharp.Threading.Tasks;

// Token: 0x020034EE RID: 13550
[NullableContext(1)]
[Nullable(0)]
[UnitTest]
public class ModelAndControllerTest : UnitTestBase
{
	// Token: 0x170026EF RID: 9967
	// (get) Token: 0x0601CA33 RID: 117299 RVA: 0x00896FEC File Offset: 0x008951EC
	public override string Name
	{
		get
		{
			return "ModelAndControllerTest";
		}
	}

	// Token: 0x0601CA34 RID: 117300 RVA: 0x00896FF4 File Offset: 0x008951F4
	[NullableContext(0)]
	public override UniTask<bool> Run([Nullable(1)] params object[] args)
	{
		if (!ModelManagerBase<ModelManager>.Instance.CreateInstance())
		{
			return UniTask.FromResult<bool>(false);
		}
		if (!ControllerManagerBase<ControllerManager>.Instance.CreateInstance())
		{
			return UniTask.FromResult<bool>(false);
		}
		if (!ModelManagerBase<ModelManager>.Instance.Init())
		{
			return UniTask.FromResult<bool>(false);
		}
		if (!ControllerManagerBase<ControllerManager>.Instance.Init())
		{
			return UniTask.FromResult<bool>(false);
		}
		Singleton<Log>.Instance.Info(ELogModule.Test, ELogAuthor.LFJW, ModelBase<ModelAndControllerTest.ModelTest>.Instance.Content, default(ReadOnlySpan<ValueTuple<string, object>>));
		ControllerBase<ModelAndControllerTest.ControllerTest>.Instance.TestFunc();
		if (!ModelManagerBase<ModelManager>.Instance.Clear())
		{
			return UniTask.FromResult<bool>(false);
		}
		ControllerManagerBase<ControllerManager>.Instance.Clear();
		return UniTask.FromResult<bool>(true);
	}

	// Token: 0x020096A2 RID: 38562
	[Nullable(new byte[]
	{
		0,
		1
	})]
	[Model(0)]
	public class ModelTest : ModelBase<ModelAndControllerTest.ModelTest>
	{
		// Token: 0x1700A904 RID: 43268
		// (get) Token: 0x0604A58D RID: 304525 RVA: 0x0142DD34 File Offset: 0x0142BF34
		// (set) Token: 0x0604A58E RID: 304526 RVA: 0x0142DD3C File Offset: 0x0142BF3C
		public string Content { get; set; } = "ModelTest";

		// Token: 0x0604A58F RID: 304527 RVA: 0x0142DD48 File Offset: 0x0142BF48
		protected override bool OnInit()
		{
			UnitTestSystem.Info("执行ModelTest的Init", default(ReadOnlySpan<ValueTuple<string, object>>));
			return true;
		}

		// Token: 0x0604A590 RID: 304528 RVA: 0x0142DD6C File Offset: 0x0142BF6C
		protected override bool OnClear()
		{
			UnitTestSystem.Info("执行ModelTest的Clear", default(ReadOnlySpan<ValueTuple<string, object>>));
			return true;
		}
	}

	// Token: 0x020096A3 RID: 38563
	[Nullable(new byte[]
	{
		0,
		1
	})]
	[Controller(0)]
	public class ControllerTest : ControllerBase<ModelAndControllerTest.ControllerTest>
	{
		// Token: 0x0604A592 RID: 304530 RVA: 0x0142DDA0 File Offset: 0x0142BFA0
		protected override bool OnInit()
		{
			UnitTestSystem.Info("执行ControllerTest的Init", default(ReadOnlySpan<ValueTuple<string, object>>));
			return true;
		}

		// Token: 0x0604A593 RID: 304531 RVA: 0x0142DDC4 File Offset: 0x0142BFC4
		protected override bool OnClear()
		{
			UnitTestSystem.Info("执行ControllerTest的Clear", default(ReadOnlySpan<ValueTuple<string, object>>));
			return true;
		}

		// Token: 0x0604A594 RID: 304532 RVA: 0x0142DDE8 File Offset: 0x0142BFE8
		public void TestFunc()
		{
			Singleton<Log>.Instance.Info(ELogModule.Test, ELogAuthor.LFJW, "调用TestFunc", default(ReadOnlySpan<ValueTuple<string, object>>));
		}
	}
}
