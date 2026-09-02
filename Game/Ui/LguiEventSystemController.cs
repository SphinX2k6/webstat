using System;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.Ui
{
	// Token: 0x02004A30 RID: 18992
	[NullableContext(1)]
	[Nullable(new byte[]
	{
		0,
		1
	})]
	public class LguiEventSystemController : ControllerBase<LguiEventSystemController>
	{
		// Token: 0x06031A18 RID: 203288 RVA: 0x00C5DA03 File Offset: 0x00C5BC03
		protected override bool OnInit()
		{
			this.AddEvents();
			return true;
		}

		// Token: 0x06031A19 RID: 203289 RVA: 0x00C5DA0C File Offset: 0x00C5BC0C
		protected override bool OnClear()
		{
			this.RemoveEvents();
			return true;
		}

		// Token: 0x06031A1A RID: 203290 RVA: 0x00C5DA18 File Offset: 0x00C5BC18
		private void AddEvents()
		{
			ControllerBase<InputDistributeController>.Instance.BindActions(new <>z__ReadOnlyArray<string>(new string[]
			{
				"UI左键点击",
				"UI右键点击"
			}), new TInputHandle<InputDistributeDefine.EActionType>(this.OnClickedMouse));
			ControllerBase<InputDistributeController>.Instance.BindAxis("WheelAxis", new TInputHandle<float>(this.OnInputWheelAxis));
		}

		// Token: 0x06031A1B RID: 203291 RVA: 0x00C5DA74 File Offset: 0x00C5BC74
		private void RemoveEvents()
		{
			ControllerBase<InputDistributeController>.Instance.UnBindActions(new <>z__ReadOnlyArray<string>(new string[]
			{
				"UI左键点击",
				"UI右键点击"
			}), new TInputHandle<InputDistributeDefine.EActionType>(this.OnClickedMouse));
			ControllerBase<InputDistributeController>.Instance.UnBindAxis("WheelAxis", new TInputHandle<float>(this.OnInputWheelAxis));
		}

		// Token: 0x06031A1C RID: 203292 RVA: 0x00C5DACD File Offset: 0x00C5BCCD
		private void OnClickedMouse(string actionName, InputDistributeDefine.EActionType actionType, InputIdentification identification)
		{
			Singleton<LguiEventSystemManager>.Instance.ClickedMouse(actionName, actionType);
		}

		// Token: 0x06031A1D RID: 203293 RVA: 0x00C5DADB File Offset: 0x00C5BCDB
		private void OnInputWheelAxis(string axisName, float value, InputIdentification identification)
		{
			Singleton<LguiEventSystemManager>.Instance.InputWheelAxis(axisName, value);
		}
	}
}
