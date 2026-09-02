using System;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.Ui
{
	// Token: 0x020049EC RID: 18924
	[NullableContext(1)]
	[Nullable(0)]
	public class InputActionHandle : InputDistributeHandle<InputDistributeDefine.EActionType>
	{
		// Token: 0x060317D5 RID: 202709 RVA: 0x00C55ACD File Offset: 0x00C53CCD
		public InputActionHandle(string inputDistributeTag, string name) : base(inputDistributeTag, name)
		{
		}

		// Token: 0x060317D6 RID: 202710 RVA: 0x00C55AD7 File Offset: 0x00C53CD7
		public void SetIsPress(bool value)
		{
			this.IsPress = value;
		}

		// Token: 0x060317D7 RID: 202711 RVA: 0x00C55AE0 File Offset: 0x00C53CE0
		public bool GetIsPress()
		{
			return this.IsPress;
		}

		// Token: 0x060317D8 RID: 202712 RVA: 0x00C55AE8 File Offset: 0x00C53CE8
		public void BindAction(TInputHandle<InputDistributeDefine.EActionType> actionCallback)
		{
			base.Bind(actionCallback);
		}

		// Token: 0x060317D9 RID: 202713 RVA: 0x00C55AF1 File Offset: 0x00C53CF1
		public void UnBindAction(TInputHandle<InputDistributeDefine.EActionType> actionCallback)
		{
			base.UnBind(actionCallback);
		}

		// Token: 0x060317DA RID: 202714 RVA: 0x00C55AFA File Offset: 0x00C53CFA
		public void BindActionIgnoreLimit(TInputHandle<InputDistributeDefine.EActionType> actionCallback)
		{
			base.BindIgnoreLimit(actionCallback);
		}

		// Token: 0x060317DB RID: 202715 RVA: 0x00C55B03 File Offset: 0x00C53D03
		public void UnBindActionIgnoreLimit(TInputHandle<InputDistributeDefine.EActionType> actionCallback)
		{
			base.UnBindIgnoreLimit(actionCallback);
		}

		// Token: 0x060317DC RID: 202716 RVA: 0x00C55B0C File Offset: 0x00C53D0C
		public void InputAction(bool bPress)
		{
			if (bPress)
			{
				base.Call(InputDistributeDefine.EActionType.Press);
			}
			else
			{
				base.Call(InputDistributeDefine.EActionType.Release);
			}
			this.IsPressTriggerAction = bPress;
		}

		// Token: 0x060317DD RID: 202717 RVA: 0x00C55B28 File Offset: 0x00C53D28
		public void InputActionIgnoreLimit(bool bPress)
		{
			if (bPress)
			{
				base.CallIgnoreLimit(InputDistributeDefine.EActionType.Press);
				return;
			}
			base.CallIgnoreLimit(InputDistributeDefine.EActionType.Release);
		}

		// Token: 0x060317DE RID: 202718 RVA: 0x00C55B3C File Offset: 0x00C53D3C
		public void TryReleaseActionIfLimitInputDistributeTag()
		{
			if (!this.IsPressTriggerAction)
			{
				return;
			}
			this.InputAction(false);
		}

		// Token: 0x0401CCAB RID: 117931
		private bool IsPress;

		// Token: 0x0401CCAC RID: 117932
		private bool IsPressTriggerAction;
	}
}
