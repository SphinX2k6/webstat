using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Module.Skin;
using CSharpScript.Game.Ui;
using UnrealEngine;

// Token: 0x02002A0D RID: 10765
[NullableContext(2)]
[Nullable(0)]
public class ShowerRoleItem : UiPanelBase
{
	// Token: 0x060157B0 RID: 87984 RVA: 0x005F46AC File Offset: 0x005F28AC
	protected override void OnRegisterComponent()
	{
		this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
		{
			new ValueTuple<int, Type>(0, typeof(UUIExtendToggle)),
			new ValueTuple<int, Type>(1, typeof(UUITexture)),
			new ValueTuple<int, Type>(2, typeof(UUITexture)),
			new ValueTuple<int, Type>(3, typeof(UUIItem)),
			new ValueTuple<int, Type>(4, typeof(UUIText))
		};
		this.BtnBindInfo = new List<ValueTuple<int, Delegate>>
		{
			new ValueTuple<int, Delegate>(0, new Action<EToggleState>(this.OnClickToggle))
		};
	}

	// Token: 0x060157B1 RID: 87985 RVA: 0x005F4758 File Offset: 0x005F2958
	public void RefreshRoleInfo(int curSelectPosIndex, RoleInstance roleInstance)
	{
		if (this.PosIndex < 0)
		{
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.Shower;
			ELogAuthor author = ELogAuthor.LRC;
			string message = "位置信息错误";
			ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("pos", this.PosIndex);
			instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
			return;
		}
		bool flag = roleInstance != null;
		UUITexture texture = base.GetTexture(1);
		if (texture != null)
		{
			texture.SetUIActive(!flag);
		}
		UUITexture texture2 = base.GetTexture(2);
		if (texture2 != null)
		{
			texture2.SetUIActive(false);
		}
		if (flag)
		{
			int roleSkinId = roleInstance.GetRoleSkinId();
			string roleHeadIconCircle = ConfigBase<SkinConfig>.Instance.GetRoleSkinConfig(roleSkinId).Value.RoleHeadIconCircle;
			base.SetRoleSkinIcon(roleHeadIconCircle, base.GetTexture(2), roleSkinId, null, delegate(bool _)
			{
				UUITexture texture3 = base.GetTexture(2);
				if (texture3 == null)
				{
					return;
				}
				texture3.SetUIActive(true);
			});
		}
		UUIText text = base.GetText(4);
		if (text != null)
		{
			text.SetText((this.PosIndex + 1).ToString(), true);
		}
		if (this.PosIndex == curSelectPosIndex)
		{
			base.GetExtendToggle(0).SetToggleState(EToggleState.ETT_Checked, false, false, false);
			return;
		}
		base.GetExtendToggle(0).SetToggleState(EToggleState.ETT_UnChecked, false, false, false);
	}

	// Token: 0x060157B2 RID: 87986 RVA: 0x005F4870 File Offset: 0x005F2A70
	public bool SetPos(int posIndex, WorldEntity entity)
	{
		if (entity == null)
		{
			return false;
		}
		this.PosIndex = posIndex;
		FVectorDouble actorLocation = entity.GetComponent<BaseActorComponent>().ActorLocation;
		Vector2D vector2D = new Vector2D();
		if (HudUnitUtils.PositionUtil.ProjectWorldToScreen(actorLocation, vector2D))
		{
			this.RootItem.SetAnchorOffset(vector2D.ToUeVector2D(false));
			return true;
		}
		return false;
	}

	// Token: 0x060157B3 RID: 87987 RVA: 0x005F48BE File Offset: 0x005F2ABE
	[NullableContext(1)]
	public void BindPosChangeCallback(Action<int> callback)
	{
		this.PosChangeCallback = callback;
	}

	// Token: 0x060157B4 RID: 87988 RVA: 0x005F48C7 File Offset: 0x005F2AC7
	private void OnClickToggle(EToggleState toggleState)
	{
		if (this.PosChangeCallback != null)
		{
			this.PosChangeCallback(this.PosIndex);
		}
	}

	// Token: 0x0400A545 RID: 42309
	private int PosIndex = -1;

	// Token: 0x0400A546 RID: 42310
	private Action<int> PosChangeCallback;

	// Token: 0x02008D8C RID: 36236
	[NullableContext(0)]
	private class EShowerRoleItemDefine
	{
		// Token: 0x0402F986 RID: 194950
		public const int Toggle = 0;

		// Token: 0x0402F987 RID: 194951
		public const int EmptyTexture = 1;

		// Token: 0x0402F988 RID: 194952
		public const int RoleIconTexture = 2;

		// Token: 0x0402F989 RID: 194953
		public const int BathNumPanel = 3;

		// Token: 0x0402F98A RID: 194954
		public const int BathNumText = 4;
	}
}
