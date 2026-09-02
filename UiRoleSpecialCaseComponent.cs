using System;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Common.Event;

// Token: 0x02002CB3 RID: 11443
[NullableContext(2)]
[Nullable(0)]
public class UiRoleSpecialCaseComponent : UiModelComponentBase
{
	// Token: 0x06016F72 RID: 94066 RVA: 0x0065DC95 File Offset: 0x0065BE95
	protected override void OnInit()
	{
		this.RoleDataComponent = base.Owner.CheckGetComponent<UiRoleDataComponent>();
		this.TagComponent = base.Owner.CheckGetComponent<UiModelTagComponent>();
	}

	// Token: 0x06016F73 RID: 94067 RVA: 0x0065DCB9 File Offset: 0x0065BEB9
	protected override void OnStart()
	{
		Singleton<EventSystem>.Instance.AddWithTarget(base.Owner, EEventName.OnUiModelRoleConfigIdChange, new Action(this.OnRoleConfigIdChange));
		this.Refresh();
	}

	// Token: 0x06016F74 RID: 94068 RVA: 0x0065DCE3 File Offset: 0x0065BEE3
	protected override void OnEnd()
	{
		Singleton<EventSystem>.Instance.RemoveWithTarget(base.Owner, EEventName.OnUiModelRoleConfigIdChange, new Action(this.OnRoleConfigIdChange));
		this.LastApplied = null;
	}

	// Token: 0x06016F75 RID: 94069 RVA: 0x0065DD0E File Offset: 0x0065BF0E
	private void OnRoleConfigIdChange()
	{
		this.Refresh();
	}

	// Token: 0x06016F76 RID: 94070 RVA: 0x0065DD18 File Offset: 0x0065BF18
	private void Refresh()
	{
		UiRoleDataComponent roleDataComponent = this.RoleDataComponent;
		int key = (roleDataComponent != null) ? roleDataComponent.RoleConfigId : 0;
		RoleSpecialCaseData roleSpecialCaseData;
		RoleSpecialCaseConfig.RoleSpecialCaseMap.TryGetValue(key, out roleSpecialCaseData);
		if (roleSpecialCaseData == this.LastApplied)
		{
			return;
		}
		this.Revert(this.LastApplied);
		this.Apply(roleSpecialCaseData);
		this.LastApplied = roleSpecialCaseData;
	}

	// Token: 0x06016F77 RID: 94071 RVA: 0x0065DD6C File Offset: 0x0065BF6C
	private void Apply(RoleSpecialCaseData data)
	{
		if (data == null || this.TagComponent == null)
		{
			return;
		}
		if (data.Tags != null)
		{
			foreach (string tagName in data.Tags)
			{
				int? num = this.ResolveTagId(tagName);
				if (num != null)
				{
					this.TagComponent.AddTagById(num.Value, Array.Empty<object>());
				}
			}
		}
	}

	// Token: 0x06016F78 RID: 94072 RVA: 0x0065DDF0 File Offset: 0x0065BFF0
	private void Revert(RoleSpecialCaseData data)
	{
		if (data == null || this.TagComponent == null)
		{
			return;
		}
		if (data.Tags != null)
		{
			foreach (string tagName in data.Tags)
			{
				int? num = this.ResolveTagId(tagName);
				if (num != null)
				{
					this.TagComponent.ReduceTagById(num.Value, Array.Empty<object>());
				}
			}
		}
	}

	// Token: 0x06016F79 RID: 94073 RVA: 0x0065DE74 File Offset: 0x0065C074
	[NullableContext(1)]
	private unsafe int? ResolveTagId(string tagName)
	{
		int tagIdByName = GameplayTagUtils.GetTagIdByName(tagName);
		if (GameplayTagUtils.GetGameplayTagById(tagIdByName) == null)
		{
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.UiComponent;
			ELogAuthor author = ELogAuthor.LJS;
			string message = "UiRoleSpecialCaseComponent: GameplayTag 不存在";
			<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray2<ValueTuple<string, object>>);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("tagName", tagName);
			ref ValueTuple<string, object> ptr = ref <PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1);
			string item = "roleConfigId";
			UiRoleDataComponent roleDataComponent = this.RoleDataComponent;
			ptr = new ValueTuple<string, object>(item, (roleDataComponent != null) ? new int?(roleDataComponent.RoleConfigId) : null);
			instance.Error(module, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 2));
			return null;
		}
		return new int?(tagIdByName);
	}

	// Token: 0x0400B118 RID: 45336
	private UiRoleDataComponent RoleDataComponent;

	// Token: 0x0400B119 RID: 45337
	private UiModelTagComponent TagComponent;

	// Token: 0x0400B11A RID: 45338
	private RoleSpecialCaseData LastApplied;
}
