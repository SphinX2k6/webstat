using System;
using System.Runtime.CompilerServices;
using AkiClient.Game.Aki.Character.Input.Structures;
using CSharpScript.Game.Input;

// Token: 0x020030A7 RID: 12455
[NullableContext(2)]
[Nullable(0)]
public class PanoramicInputLayer : InputLayer
{
	// Token: 0x06019AA7 RID: 105127 RVA: 0x0077673F File Offset: 0x0077493F
	public void Init()
	{
	}

	// Token: 0x06019AA8 RID: 105128 RVA: 0x00776741 File Offset: 0x00774941
	public override EInputLayer GetLayerType()
	{
		return EInputLayer.Panoramic;
	}

	// Token: 0x06019AA9 RID: 105129 RVA: 0x00776748 File Offset: 0x00774948
	public override SInputCommand HandleRelease(EInputAction action, float time)
	{
		if (action == 13)
		{
			Singleton<Log>.Instance.Info(ELogModule.Panoramic, ELogAuthor.JYS, "[环视] HandleRelease1 锁定目标 HandleRelease", default(ReadOnlySpan<ValueTuple<string, object>>));
			return InputLayer.GetSwallowCommand();
		}
		return null;
	}

	// Token: 0x06019AAA RID: 105130 RVA: 0x00776785 File Offset: 0x00774985
	public override SInputCommand HandlePress(EInputAction action, float time)
	{
		if (action == 13)
		{
			ControllerBase<PanoramicController>.Instance.InteractPawn();
			return InputLayer.GetSwallowCommand();
		}
		return null;
	}

	// Token: 0x06019AAB RID: 105131 RVA: 0x007767A2 File Offset: 0x007749A2
	public override SInputCommand HandleHold(EInputAction action, float time)
	{
		if (action == 13)
		{
			return InputLayer.GetSwallowCommand();
		}
		return null;
	}

	// Token: 0x06019AAC RID: 105132 RVA: 0x007767B8 File Offset: 0x007749B8
	public override bool CheckBlockDispatchEvent(EInputAction action)
	{
		bool result = false;
		if (action == 13)
		{
			result = true;
		}
		Log instance = Singleton<Log>.Instance;
		ELogModule module = ELogModule.Panoramic;
		ELogAuthor author = ELogAuthor.JYS;
		string message = "[环视] 忽略DispatchEvent事件";
		ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("action", action);
		instance.Info(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
		return result;
	}
}
