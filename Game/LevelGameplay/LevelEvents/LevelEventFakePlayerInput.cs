using System;
using System.Runtime.CompilerServices;
using Aki.TDConfigMgr.Action;
using AkiClient.Game.Aki.Character.Input.Enum;
using CSharpScript.Game.Input;

namespace CSharpScript.Game.LevelGamePlay.LevelEvents
{
	// Token: 0x02006BA2 RID: 27554
	public class LevelEventFakePlayerInput : LevelEventBase
	{
		// Token: 0x06043FB9 RID: 278457 RVA: 0x0119DBB8 File Offset: 0x0119BDB8
		public LevelEventFakePlayerInput(int id) : base(id)
		{
		}

		// Token: 0x06043FBA RID: 278458 RVA: 0x0119DBC4 File Offset: 0x0119BDC4
		[NullableContext(1)]
		public override void ExecuteNew(ActionParams inParams, GeneralContext context, int? actionId = null)
		{
			if (inParams == null)
			{
				Singleton<global::Log>.Instance.Error(ELogModule.LevelEvent, ELogAuthor.CH, "[LevelEventFakePlayerInput] 参数配置错误", default(ReadOnlySpan<ValueTuple<string, object>>));
			}
			this.Params = (inParams as PlayerInput);
			CSharpScript.Game.Input.EInputAction einputAction = CSharpScript.Game.Input.EInputAction.None;
			switch (this.Params.Input)
			{
			case EPlayerInputType.跳跃:
				einputAction = CSharpScript.Game.Input.EInputAction.跳跃;
				break;
			case EPlayerInputType.攻击:
				einputAction = CSharpScript.Game.Input.EInputAction.攻击;
				break;
			case EPlayerInputType.闪避:
				einputAction = CSharpScript.Game.Input.EInputAction.闪避;
				break;
			case EPlayerInputType.技能1:
				einputAction = CSharpScript.Game.Input.EInputAction.技能1;
				break;
			case EPlayerInputType.幻象1:
				einputAction = CSharpScript.Game.Input.EInputAction.幻象1;
				break;
			case EPlayerInputType.大招:
				einputAction = CSharpScript.Game.Input.EInputAction.大招;
				break;
			case EPlayerInputType.幻象2:
				einputAction = CSharpScript.Game.Input.EInputAction.幻象2;
				break;
			}
			if (einputAction == CSharpScript.Game.Input.EInputAction.None)
			{
				global::Log instance = Singleton<global::Log>.Instance;
				ELogModule module = ELogModule.LevelEvent;
				ELogAuthor author = ELogAuthor.CH;
				string message = "[LevelEventFakePlayerInput] 未知的输入类型";
				ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("Input", this.Params.Input);
				instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
				return;
			}
			ControllerBase<InputController>.Instance.InputAction(einputAction, EInputState.Press);
			ControllerBase<InputController>.Instance.InputAction(einputAction, EInputState.Release);
		}

		// Token: 0x0402601F RID: 155679
		[Nullable(2)]
		private PlayerInput Params;
	}
}
