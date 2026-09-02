using System;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Common.Event;

// Token: 0x02003154 RID: 12628
[NullableContext(1)]
[Nullable(0)]
public class SpecialSkillXigelika : SpecialSkillBase
{
	// Token: 0x0601A28B RID: 107147 RVA: 0x007AE1A0 File Offset: 0x007AC3A0
	public SpecialSkillXigelika(CharacterSpecialSkillComponent specialSkillComponent) : base(specialSkillComponent)
	{
	}

	// Token: 0x0601A28C RID: 107148 RVA: 0x007AE328 File Offset: 0x007AC528
	public override void OnStart()
	{
		this.Entity = this.SpecialSkillComponent.Entity;
		this.TagComponent = this.Entity.GetComponent<RoleTagComponent>();
		this.BuffComponent = this.Entity.GetComponent<RoleBuffComponent>();
		Singleton<EventSystem>.Instance.AddWithTarget(this.Entity, EEventName.CharOnRoleDeadTargetSelf, new Action(this.OnRoleDead));
		RoleTagComponent tagComponent = this.TagComponent;
		this.ResetTagListener = ((tagComponent != null) ? tagComponent.ListenForTagAddOrRemove(new int?(this.resetTag), new BaseTagComponent.TTagSwitchedCallback(this.OnTagChange), null) : null);
	}

	// Token: 0x0601A28D RID: 107149 RVA: 0x007AE3BC File Offset: 0x007AC5BC
	public override void OnEnd()
	{
		if (this.Entity != null)
		{
			Singleton<EventSystem>.Instance.RemoveWithTarget(this.Entity, EEventName.CharOnRoleDeadTargetSelf, new Action(this.OnRoleDead));
		}
		ITagTask resetTagListener = this.ResetTagListener;
		if (resetTagListener != null)
		{
			resetTagListener.EndTask();
		}
		this.ResetTagListener = null;
	}

	// Token: 0x0601A28E RID: 107150 RVA: 0x007AE40B File Offset: 0x007AC60B
	public override void OnDisable()
	{
	}

	// Token: 0x0601A28F RID: 107151 RVA: 0x007AE40D File Offset: 0x007AC60D
	private void OnRoleDead()
	{
		this.ResetBean();
	}

	// Token: 0x0601A290 RID: 107152 RVA: 0x007AE415 File Offset: 0x007AC615
	private void OnTagChange(int tagId, bool tagExists)
	{
		if (tagExists)
		{
			this.ResetBean();
		}
	}

	// Token: 0x0601A291 RID: 107153 RVA: 0x007AE420 File Offset: 0x007AC620
	public int AddBean(string bean)
	{
		if (this.BeanFull)
		{
			return 0;
		}
		if (bean != "A" && bean != "B")
		{
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.Battle;
			ELogAuthor author = ELogAuthor.ZFJ;
			string message = "[SpecialSkillXigelika]印记名字错误";
			ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("Name", bean);
			instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
			return 0;
		}
		int size = this.BeanQueue.Size;
		this.PushBean(bean);
		Log instance2 = Singleton<Log>.Instance;
		ELogModule module2 = ELogModule.Battle;
		ELogAuthor author2 = ELogAuthor.ZFJ;
		string message2 = "[SpecialSkillXigelika]普通加印记";
		ValueTuple<string, object> valueTuple2 = new ValueTuple<string, object>("印记", bean);
		instance2.Info(module2, author2, message2, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple2));
		RoleTagComponent tagComponent = this.TagComponent;
		if (tagComponent != null && tagComponent.HasTag(GameplayTagDefine.EGameplayTagId["角色.R2T1XigelikaMd10011.状态标识.复读"]))
		{
			Log instance3 = Singleton<Log>.Instance;
			ELogModule module3 = ELogModule.Battle;
			ELogAuthor author3 = ELogAuthor.ZFJ;
			string message3 = "[SpecialSkillXigelika]复读加印记";
			ValueTuple<string, object> valueTuple3 = new ValueTuple<string, object>("印记", bean);
			instance3.Info(module3, author3, message3, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple3));
			this.PushBean(bean);
			RoleBuffComponent buffComponent = this.BuffComponent;
			if (buffComponent != null)
			{
				buffComponent.RemoveBuff(1412301005L, -1, "Xigelika复读消耗", null, null, null);
			}
		}
		else
		{
			RoleTagComponent tagComponent2 = this.TagComponent;
			if (tagComponent2 != null && tagComponent2.HasTag(GameplayTagDefine.EGameplayTagId["角色.R2T1XigelikaMd10011.状态标识.速读"]))
			{
				string text = (bean == "A") ? "B" : "A";
				Log instance4 = Singleton<Log>.Instance;
				ELogModule module4 = ELogModule.Battle;
				ELogAuthor author4 = ELogAuthor.ZFJ;
				string message4 = "[SpecialSkillXigelika]速读加印记";
				ValueTuple<string, object> valueTuple4 = new ValueTuple<string, object>("印记", text);
				instance4.Info(module4, author4, message4, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple4));
				this.PushBean(text);
				RoleBuffComponent buffComponent2 = this.BuffComponent;
				if (buffComponent2 != null)
				{
					buffComponent2.RemoveBuff(1412401001L, -1, "Xigelika速读消耗", null, null, null);
				}
			}
		}
		this.RefreshBeanTag();
		return this.BeanQueue.Size - size;
	}

	// Token: 0x0601A292 RID: 107154 RVA: 0x007AE607 File Offset: 0x007AC807
	private void PushBean(string bean)
	{
		if (this.BeanQueue.Size == 2)
		{
			this.BeanQueue.Pop();
		}
		this.BeanQueue.Push(bean);
	}

	// Token: 0x0601A293 RID: 107155 RVA: 0x007AE630 File Offset: 0x007AC830
	public int GetBeanResultant()
	{
		RoleTagComponent tagComponent = this.TagComponent;
		int num;
		if (tagComponent == null || !tagComponent.HasAllTag(new <>z__ReadOnlyArray<int>(new int[]
		{
			this.locTagA[0],
			this.locTagA[1]
		})))
		{
			RoleTagComponent tagComponent2 = this.TagComponent;
			if (tagComponent2 == null || !tagComponent2.HasAllTag(new <>z__ReadOnlyArray<int>(new int[]
			{
				this.locTagA[2],
				this.locTagA[3]
			})))
			{
				RoleTagComponent tagComponent3 = this.TagComponent;
				if (tagComponent3 == null || !tagComponent3.HasAllTag(new <>z__ReadOnlyArray<int>(new int[]
				{
					this.locTagB[0],
					this.locTagB[1]
				})))
				{
					RoleTagComponent tagComponent4 = this.TagComponent;
					if (tagComponent4 == null || !tagComponent4.HasAllTag(new <>z__ReadOnlyArray<int>(new int[]
					{
						this.locTagB[2],
						this.locTagB[3]
					})))
					{
						num = 3;
						goto IL_DE;
					}
				}
				num = 2;
				goto IL_DE;
			}
		}
		num = 1;
		IL_DE:
		Log instance = Singleton<Log>.Instance;
		ELogModule module = ELogModule.Battle;
		ELogAuthor author = ELogAuthor.ZFJ;
		string message = "[SpecialSkillXigelika]印记组合结果";
		ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("结果", num);
		instance.Info(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
		return num;
	}

	// Token: 0x0601A294 RID: 107156 RVA: 0x007AE748 File Offset: 0x007AC948
	public void ConsumeBean()
	{
		Singleton<Log>.Instance.Info(ELogModule.Battle, ELogAuthor.ZFJ, "[SpecialSkillXigelika]消耗印记", default(ReadOnlySpan<ValueTuple<string, object>>));
		foreach (int num in this.locTagA)
		{
			RoleTagComponent tagComponent = this.TagComponent;
			if (tagComponent != null && tagComponent.HasTag(num))
			{
				this.TagComponent.RemoveTag(new int?(num));
			}
		}
		foreach (int num2 in this.locTagB)
		{
			RoleTagComponent tagComponent2 = this.TagComponent;
			if (tagComponent2 != null && tagComponent2.HasTag(num2))
			{
				this.TagComponent.RemoveTag(new int?(num2));
			}
		}
		int num3 = this.BeanUsing ? 2 : 0;
		for (int j = 0; j < 2; j++)
		{
			if (this.BeanQueue.Size > j)
			{
				string text = this.BeanQueue.Get(j);
				if (text != null)
				{
					int num4 = (text == "A") ? this.locUsedTagA[j + num3] : this.locUsedTagB[j + num3];
					RoleTagComponent tagComponent3 = this.TagComponent;
					if (tagComponent3 == null || !tagComponent3.HasTag(num4))
					{
						RoleTagComponent tagComponent4 = this.TagComponent;
						if (tagComponent4 != null)
						{
							tagComponent4.AddTag(new int?(num4));
						}
					}
				}
			}
		}
		this.BeanQueue.Clear();
		if (this.BeanUsing)
		{
			this.BeanFull = true;
		}
		this.BeanUsing = true;
	}

	// Token: 0x0601A295 RID: 107157 RVA: 0x007AE8B8 File Offset: 0x007ACAB8
	private void RefreshBeanTag()
	{
		int num = this.BeanUsing ? 2 : 0;
		for (int i = 0; i < this.BeanQueue.Size; i++)
		{
			string text = this.BeanQueue.Get(i);
			if (text != null)
			{
				int num2 = (text == "A") ? this.locTagA[i + num] : this.locTagB[i + num];
				int num3 = (text == "A") ? this.locTagB[i + num] : this.locTagA[i + num];
				RoleTagComponent tagComponent = this.TagComponent;
				if (tagComponent != null && tagComponent.HasTag(num3))
				{
					this.TagComponent.RemoveTag(new int?(num3));
				}
				RoleTagComponent tagComponent2 = this.TagComponent;
				if (tagComponent2 == null || !tagComponent2.HasTag(num2))
				{
					RoleTagComponent tagComponent3 = this.TagComponent;
					if (tagComponent3 != null)
					{
						tagComponent3.AddTag(new int?(num2));
					}
				}
			}
		}
	}

	// Token: 0x0601A296 RID: 107158 RVA: 0x007AE9A4 File Offset: 0x007ACBA4
	public void ResetBean()
	{
		Singleton<Log>.Instance.Info(ELogModule.Battle, ELogAuthor.ZFJ, "[SpecialSkillXigelika]重置印记", default(ReadOnlySpan<ValueTuple<string, object>>));
		foreach (int num in this.locTagA)
		{
			RoleTagComponent tagComponent = this.TagComponent;
			if (tagComponent != null && tagComponent.HasTag(num))
			{
				this.TagComponent.RemoveTag(new int?(num));
			}
		}
		foreach (int num2 in this.locTagB)
		{
			RoleTagComponent tagComponent2 = this.TagComponent;
			if (tagComponent2 != null && tagComponent2.HasTag(num2))
			{
				this.TagComponent.RemoveTag(new int?(num2));
			}
		}
		foreach (int num3 in this.locUsedTagA)
		{
			RoleTagComponent tagComponent3 = this.TagComponent;
			if (tagComponent3 != null && tagComponent3.HasTag(num3))
			{
				this.TagComponent.RemoveTag(new int?(num3));
			}
		}
		foreach (int num4 in this.locUsedTagB)
		{
			RoleTagComponent tagComponent4 = this.TagComponent;
			if (tagComponent4 != null && tagComponent4.HasTag(num4))
			{
				this.TagComponent.RemoveTag(new int?(num4));
			}
		}
		this.BeanQueue.Clear();
		this.BeanFull = false;
		this.BeanUsing = false;
	}

	// Token: 0x0400D23E RID: 53822
	private const int QUEUE_MAX_LENGTH = 2;

	// Token: 0x0400D23F RID: 53823
	private const string BEAN_A = "A";

	// Token: 0x0400D240 RID: 53824
	private const string BEAN_B = "B";

	// Token: 0x0400D241 RID: 53825
	private const long FUDU_BUFF = 1412301005L;

	// Token: 0x0400D242 RID: 53826
	private const long SUDU_BUFF = 1412401001L;

	// Token: 0x0400D243 RID: 53827
	private const int AA = 1;

	// Token: 0x0400D244 RID: 53828
	private const int BB = 2;

	// Token: 0x0400D245 RID: 53829
	private const int AB = 3;

	// Token: 0x0400D246 RID: 53830
	private readonly int resetTag = GameplayTagDefine.EGameplayTagId["角色.R2T1XigelikaMd10011.状态标识.两符文已使用"];

	// Token: 0x0400D247 RID: 53831
	private readonly int[] locTagA = new int[]
	{
		GameplayTagDefine.EGameplayTagId["角色.R2T1XigelikaMd10011.状态标识.A印记1"],
		GameplayTagDefine.EGameplayTagId["角色.R2T1XigelikaMd10011.状态标识.A印记2"],
		GameplayTagDefine.EGameplayTagId["角色.R2T1XigelikaMd10011.状态标识.A印记3"],
		GameplayTagDefine.EGameplayTagId["角色.R2T1XigelikaMd10011.状态标识.A印记4"]
	};

	// Token: 0x0400D248 RID: 53832
	private readonly int[] locTagB = new int[]
	{
		GameplayTagDefine.EGameplayTagId["角色.R2T1XigelikaMd10011.状态标识.B印记1"],
		GameplayTagDefine.EGameplayTagId["角色.R2T1XigelikaMd10011.状态标识.B印记2"],
		GameplayTagDefine.EGameplayTagId["角色.R2T1XigelikaMd10011.状态标识.B印记3"],
		GameplayTagDefine.EGameplayTagId["角色.R2T1XigelikaMd10011.状态标识.B印记4"]
	};

	// Token: 0x0400D249 RID: 53833
	private readonly int[] locUsedTagA = new int[]
	{
		GameplayTagDefine.EGameplayTagId["角色.R2T1XigelikaMd10011.状态标识.已使用A印记1"],
		GameplayTagDefine.EGameplayTagId["角色.R2T1XigelikaMd10011.状态标识.已使用A印记2"],
		GameplayTagDefine.EGameplayTagId["角色.R2T1XigelikaMd10011.状态标识.已使用A印记3"],
		GameplayTagDefine.EGameplayTagId["角色.R2T1XigelikaMd10011.状态标识.已使用A印记4"]
	};

	// Token: 0x0400D24A RID: 53834
	private readonly int[] locUsedTagB = new int[]
	{
		GameplayTagDefine.EGameplayTagId["角色.R2T1XigelikaMd10011.状态标识.已使用B印记1"],
		GameplayTagDefine.EGameplayTagId["角色.R2T1XigelikaMd10011.状态标识.已使用B印记2"],
		GameplayTagDefine.EGameplayTagId["角色.R2T1XigelikaMd10011.状态标识.已使用B印记3"],
		GameplayTagDefine.EGameplayTagId["角色.R2T1XigelikaMd10011.状态标识.已使用B印记4"]
	};

	// Token: 0x0400D24B RID: 53835
	private readonly Queue<string> BeanQueue = new Queue<string>(4);

	// Token: 0x0400D24C RID: 53836
	private bool BeanUsing;

	// Token: 0x0400D24D RID: 53837
	private bool BeanFull;

	// Token: 0x0400D24E RID: 53838
	[Nullable(2)]
	private Entity Entity;

	// Token: 0x0400D24F RID: 53839
	[Nullable(2)]
	private RoleTagComponent TagComponent;

	// Token: 0x0400D250 RID: 53840
	[Nullable(2)]
	private RoleBuffComponent BuffComponent;

	// Token: 0x0400D251 RID: 53841
	[Nullable(2)]
	private ITagTask ResetTagListener;
}
