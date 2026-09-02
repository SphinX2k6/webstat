using System;
using System.Runtime.CompilerServices;
using AkiClient.Game.Aki.Character.Input.Blueprints;
using AkiClient.Game.Aki.Character.Input.Structures;
using CSharpScript.Game.Input;
using UnrealEngine;

// Token: 0x020030A0 RID: 12448
[NullableContext(2)]
[Nullable(0)]
public class CharacterInputLayer : InputLayer
{
	// Token: 0x06019A5A RID: 105050 RVA: 0x00774B48 File Offset: 0x00772D48
	[NullableContext(1)]
	public void Init(EntityHandle entityHandle)
	{
		WorldEntity entity = entityHandle.Entity;
		CharacterActorComponent component = entity.GetComponent<CharacterActorComponent>();
		TsBaseCharacter role = component.Actor;
		this.CharacterInputComp = entity.GetComponent<CharacterInputComponent>();
		this.ResetBpInputComp();
		if (this.BpInputComp != null)
		{
			this.OnBpInputCompChanged();
			return;
		}
		FSoftClassPath inputComponentClass2 = role.InputComponentClass;
		string text = ((inputComponentClass2 != null) ? inputComponentClass2.AssetPathName.ToString() : null) ?? "";
		if (text != "")
		{
			Singleton<ResourceSystem>.Instance.LoadAsync<UBlueprintGeneratedClass>(text, delegate([Nullable(2)] UBlueprintGeneratedClass inputComponentClass, string _)
			{
				this.BpInputComp = (role.AddComponentByClass(inputComponentClass, false, Singleton<MathUtils>.Instance.DefaultTransform, false, default(FName)) as BP_InputBase_C);
				this.BpInputComp.OwnerActor = role;
				this.BpInputCompOrigin = this.BpInputComp;
				this.OnBpInputCompChanged();
			}, 100, "js_undefined");
			return;
		}
		Log instance = Singleton<Log>.Instance;
		ELogModule module = ELogModule.Input;
		ELogAuthor author = ELogAuthor.WWJ;
		string message = "[CharacterInputLayer]加载BpInput失败";
		ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("Role", role);
		instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
	}

	// Token: 0x06019A5B RID: 105051 RVA: 0x00774C26 File Offset: 0x00772E26
	public override void Clear()
	{
		this.BpInputComp = null;
		this.BpInputCompOrigin = null;
	}

	// Token: 0x06019A5C RID: 105052 RVA: 0x00774C36 File Offset: 0x00772E36
	public override EInputLayer GetLayerType()
	{
		return EInputLayer.Character;
	}

	// Token: 0x06019A5D RID: 105053 RVA: 0x00774C3C File Offset: 0x00772E3C
	public override SInputCommand HandlePress(EInputAction action, float time)
	{
		if (this.BpInputComp == null)
		{
			return null;
		}
		SInputCommand result = null;
		switch (action)
		{
		case 1:
			result = this.BpInputComp.跳跃按下(time);
			break;
		case 2:
			result = this.BpInputComp.攀爬按下(time);
			break;
		case 3:
			result = this.BpInputComp.走跑切换按下(time);
			break;
		case 4:
			result = this.BpInputComp.攻击按下(time);
			break;
		case 5:
			result = this.BpInputComp.闪避按下(time);
			break;
		case 6:
			result = this.BpInputComp.技能1按下(time);
			break;
		case 7:
			result = this.BpInputComp.幻象1按下(time);
			break;
		case 8:
			result = this.BpInputComp.大招按下(time);
			break;
		case 9:
			result = this.BpInputComp.幻象2按下(time);
			break;
		case 10:
			result = this.BpInputComp.切换角色1按下(time);
			break;
		case 11:
			result = this.BpInputComp.切换角色2按下(time);
			break;
		case 12:
			result = this.BpInputComp.切换角色3按下(time);
			break;
		case 14:
			result = this.BpInputComp.瞄准按下(time);
			break;
		case 15:
			result = this.BpInputComp.通用交互按下(time);
			break;
		case 16:
			result = this.BpInputComp.下降按下(time);
			break;
		}
		return result;
	}

	// Token: 0x06019A5E RID: 105054 RVA: 0x00774D9C File Offset: 0x00772F9C
	public override SInputCommand HandleRelease(EInputAction action, float time)
	{
		if (this.BpInputComp == null)
		{
			return null;
		}
		SInputCommand result = null;
		switch (action)
		{
		case 1:
			result = this.BpInputComp.跳跃抬起(time);
			break;
		case 2:
			result = this.BpInputComp.攀爬抬起(time);
			break;
		case 3:
			result = this.BpInputComp.走跑切换抬起(time);
			break;
		case 4:
			result = this.BpInputComp.攻击抬起(time);
			break;
		case 5:
			result = this.BpInputComp.闪避抬起(time);
			break;
		case 6:
			result = this.BpInputComp.技能1抬起(time);
			break;
		case 7:
			result = this.BpInputComp.幻象1抬起(time);
			break;
		case 8:
			result = this.BpInputComp.大招抬起(time);
			break;
		case 9:
			result = this.BpInputComp.幻象2抬起(time);
			break;
		case 10:
			result = this.BpInputComp.切换角色1抬起(time);
			break;
		case 11:
			result = this.BpInputComp.切换角色2抬起(time);
			break;
		case 12:
			result = this.BpInputComp.切换角色3抬起(time);
			break;
		case 14:
			result = this.BpInputComp.瞄准抬起(time);
			break;
		case 16:
			result = this.BpInputComp.下降抬起(time);
			break;
		}
		return result;
	}

	// Token: 0x06019A5F RID: 105055 RVA: 0x00774EEC File Offset: 0x007730EC
	public override SInputCommand HandleHold(EInputAction action, float time)
	{
		if (this.BpInputComp == null)
		{
			return null;
		}
		switch (action)
		{
		case 1:
			return this.BpInputComp.跳跃长按(time);
		case 2:
			return this.BpInputComp.攀爬长按(time);
		case 3:
			return this.BpInputComp.走跑切换长按(time);
		case 4:
			return this.BpInputComp.攻击长按(time);
		case 5:
			return this.BpInputComp.闪避长按(time);
		case 6:
			return this.BpInputComp.技能1长按(time);
		case 7:
			return this.BpInputComp.幻象1长按(time);
		case 8:
			return this.BpInputComp.大招长按(time);
		case 9:
			return this.BpInputComp.幻象2长按(time);
		case 10:
			return this.BpInputComp.切换角色1长按(time);
		case 11:
			return this.BpInputComp.切换角色2长按(time);
		case 12:
			return this.BpInputComp.切换角色3长按(time);
		case 13:
			return this.BpInputComp.锁定目标长按(time);
		case 14:
			return this.BpInputComp.瞄准长按(time);
		case 16:
			return this.BpInputComp.下降长按(time);
		}
		return null;
	}

	// Token: 0x06019A60 RID: 105056 RVA: 0x0077501C File Offset: 0x0077321C
	public override void DispatchPressEvent(EInputAction action, float time)
	{
		if (this.BpInputComp == null)
		{
			return;
		}
		switch (action)
		{
		case 1:
			this.BpInputComp.跳跃按下事件(time);
			return;
		case 2:
			this.BpInputComp.攀爬按下事件(time);
			return;
		case 3:
			this.BpInputComp.走跑切换按下事件(time);
			return;
		case 4:
			this.BpInputComp.攻击按下事件(time);
			return;
		case 5:
			this.BpInputComp.闪避按下事件(time);
			return;
		case 6:
			this.BpInputComp.技能1按下事件(time);
			return;
		case 7:
			this.BpInputComp.幻象1按下事件(time);
			return;
		case 8:
			this.BpInputComp.大招按下事件(time);
			return;
		case 9:
			this.BpInputComp.幻象2按下事件(time);
			return;
		case 10:
			this.BpInputComp.切换角色1按下事件(time);
			return;
		case 11:
			this.BpInputComp.切换角色2按下事件(time);
			return;
		case 12:
			this.BpInputComp.切换角色3按下事件(time);
			return;
		case 13:
			this.BpInputComp.锁定目标按下事件(time);
			return;
		case 14:
			this.BpInputComp.瞄准按下事件(time);
			return;
		case 15:
			break;
		case 16:
			this.BpInputComp.下降按下事件(time);
			break;
		default:
			return;
		}
	}

	// Token: 0x06019A61 RID: 105057 RVA: 0x00775144 File Offset: 0x00773344
	public override void DispatchReleaseEvent(EInputAction action, float time)
	{
		if (this.BpInputComp == null)
		{
			return;
		}
		switch (action)
		{
		case 1:
			this.BpInputComp.跳跃抬起事件(time);
			return;
		case 2:
			this.BpInputComp.攀爬抬起事件(time);
			return;
		case 3:
			this.BpInputComp.走跑切换抬起事件(time);
			return;
		case 4:
			this.BpInputComp.攻击抬起事件(time);
			return;
		case 5:
			this.BpInputComp.闪避抬起事件(time);
			return;
		case 6:
			this.BpInputComp.技能1抬起事件(time);
			return;
		case 7:
			this.BpInputComp.幻象1抬起事件(time);
			return;
		case 8:
			this.BpInputComp.大招抬起事件(time);
			return;
		case 9:
			this.BpInputComp.幻象2抬起事件(time);
			return;
		case 10:
			this.BpInputComp.切换角色1抬起事件(time);
			return;
		case 11:
			this.BpInputComp.切换角色2抬起事件(time);
			return;
		case 12:
			this.BpInputComp.切换角色3抬起事件(time);
			return;
		case 13:
			this.BpInputComp.锁定目标抬起事件(time);
			return;
		case 14:
			this.BpInputComp.瞄准抬起事件(time);
			return;
		case 15:
			break;
		case 16:
			this.BpInputComp.下降抬起事件(time);
			break;
		default:
			return;
		}
	}

	// Token: 0x06019A62 RID: 105058 RVA: 0x0077526C File Offset: 0x0077346C
	public override SInputCommand HandlePressEx(EInputAction action, float time, float param = 0f)
	{
		if (this.BpInputComp == null)
		{
			return null;
		}
		if (action == EInputAction.移动输入按键事件)
		{
			return this.BpInputComp.移动输入按下(time, param);
		}
		return this.HandlePress(action, time);
	}

	// Token: 0x06019A63 RID: 105059 RVA: 0x0077529B File Offset: 0x0077349B
	public override SInputCommand HandleReleaseEx(EInputAction action, float time, float param = 0f)
	{
		if (this.BpInputComp == null)
		{
			return null;
		}
		if (action == EInputAction.移动输入按键事件)
		{
			return this.BpInputComp.移动输入抬起(time, param);
		}
		return this.HandleRelease(action, time);
	}

	// Token: 0x06019A64 RID: 105060 RVA: 0x007752CA File Offset: 0x007734CA
	public override SInputCommand HandleHoldEx(EInputAction action, float time, float param = 0f)
	{
		if (this.BpInputComp == null)
		{
			return null;
		}
		if (action == EInputAction.移动输入按键事件)
		{
			return this.BpInputComp.移动输入长按(time, param);
		}
		return this.HandleHold(action, time);
	}

	// Token: 0x06019A65 RID: 105061 RVA: 0x007752F9 File Offset: 0x007734F9
	public override void DispatchPressEventEx(EInputAction action, float time, float param = 0f)
	{
		if (this.BpInputComp == null)
		{
			return;
		}
		if (action == EInputAction.移动输入按键事件)
		{
			this.BpInputComp.移动输入按下事件(time, param);
			return;
		}
		this.DispatchPressEvent(action, time);
	}

	// Token: 0x06019A66 RID: 105062 RVA: 0x00775327 File Offset: 0x00773527
	public override void DispatchReleaseEventEx(EInputAction action, float time, float param = 0f)
	{
		if (this.BpInputComp == null)
		{
			return;
		}
		if (action == EInputAction.移动输入按键事件)
		{
			this.BpInputComp.移动输入抬起事件(time, param);
			return;
		}
		this.DispatchReleaseEvent(action, time);
	}

	// Token: 0x06019A67 RID: 105063 RVA: 0x00775355 File Offset: 0x00773555
	public BP_InputBase_C GetBpInputComp()
	{
		return this.BpInputComp;
	}

	// Token: 0x06019A68 RID: 105064 RVA: 0x0077535D File Offset: 0x0077355D
	public void SetBpInputComp(BP_InputBase_C bpInputComp)
	{
		this.BpInputComp = bpInputComp;
		this.OnBpInputCompChanged();
	}

	// Token: 0x06019A69 RID: 105065 RVA: 0x0077536C File Offset: 0x0077356C
	public void ResetBpInputComp()
	{
		this.BpInputComp = this.BpInputCompOrigin;
		this.OnBpInputCompChanged();
	}

	// Token: 0x06019A6A RID: 105066 RVA: 0x00775380 File Offset: 0x00773580
	private void OnBpInputCompChanged()
	{
		CharacterInputComponent characterInputComp = this.CharacterInputComp;
		if (characterInputComp == null)
		{
			return;
		}
		characterInputComp.OnBpInputCompChanged();
	}

	// Token: 0x0400CC41 RID: 52289
	[Nullable(1)]
	[StaticVariableRuleIgnore]
	private static readonly Stat HandlePressStat = Stat.Create("CharacterInputLayer.HandlePress", "", "");

	// Token: 0x0400CC42 RID: 52290
	[Nullable(1)]
	[StaticVariableRuleIgnore]
	private static readonly Stat HandleReleaseStat = Stat.Create("CharacterInputLayer.HandleRelease", "", "");

	// Token: 0x0400CC43 RID: 52291
	[Nullable(1)]
	[StaticVariableRuleIgnore]
	private static readonly Stat HandlePressExStat = Stat.Create("CharacterInputLayer.HandlePressEx", "", "");

	// Token: 0x0400CC44 RID: 52292
	[Nullable(1)]
	[StaticVariableRuleIgnore]
	private static readonly Stat HandleReleaseExStat = Stat.Create("CharacterInputLayer.HandleReleaseEx", "", "");

	// Token: 0x0400CC45 RID: 52293
	private BP_InputBase_C BpInputComp;

	// Token: 0x0400CC46 RID: 52294
	private BP_InputBase_C BpInputCompOrigin;

	// Token: 0x0400CC47 RID: 52295
	private CharacterInputComponent CharacterInputComp;
}
