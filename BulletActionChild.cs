using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnrealEngine;

// Token: 0x02002D7F RID: 11647
public class BulletActionChild : BulletActionBase
{
	// Token: 0x060177F1 RID: 96241 RVA: 0x0068339E File Offset: 0x0068159E
	public BulletActionChild(EBulletAction type) : base(type)
	{
	}

	// Token: 0x060177F2 RID: 96242 RVA: 0x006833A8 File Offset: 0x006815A8
	protected override void OnExecute()
	{
		this.ChildInfo = new BulletChildInfo();
		this.BulletInfo.ChildInfo = this.ChildInfo;
		this.ChildInfo.HaveSummonedBulletNumber = new List<int>();
		this.ChildBulletData = this.BulletInfo.BulletDataMain.Children;
		int num = this.ChildBulletData.Length;
		for (int i = 0; i < num; i++)
		{
			this.ChildInfo.HaveSummonedBulletNumber.Add(0);
		}
		this.SetSpecialChildrenBullet();
	}

	// Token: 0x060177F3 RID: 96243 RVA: 0x00683423 File Offset: 0x00681623
	public override void Clear()
	{
		base.Clear();
		this.ChildInfo = null;
		this.ChildBulletData = null;
	}

	// Token: 0x060177F4 RID: 96244 RVA: 0x0068343C File Offset: 0x0068163C
	private void SetSpecialChildrenBullet()
	{
		BulletDataChild[] childBulletData = this.ChildBulletData;
		for (int i = 0; i < childBulletData.Length; i++)
		{
			if (childBulletData[i].Condition == EBulletChildrenType.OnHitObstacle)
			{
				this.ChildInfo.HaveSpecialChildrenBullet = true;
				return;
			}
		}
	}

	// Token: 0x060177F5 RID: 96245 RVA: 0x00683476 File Offset: 0x00681676
	protected override void OnTick(float delta)
	{
		if (!this.BulletInfo.NeedDestroy)
		{
			this.UpdateSummonChildBullet();
		}
	}

	// Token: 0x060177F6 RID: 96246 RVA: 0x0068348C File Offset: 0x0068168C
	private void UpdateSummonChildBullet()
	{
		int num = this.ChildBulletData.Length;
		for (int i = 0; i < num; i++)
		{
			BulletDataChild bulletDataChild = this.ChildBulletData[i];
			int num2 = i;
			if ((float)bulletDataChild.RowName > 0.0001f && bulletDataChild.Condition == EBulletChildrenType.Normal && (bulletDataChild.Num <= 0 || this.ChildInfo.HaveSummonedBulletNumber[num2] < bulletDataChild.Num))
			{
				if (bulletDataChild.Delay < 0f)
				{
					Log instance = Singleton<Log>.Instance;
					ELogModule module = ELogModule.Bullet;
					ELogAuthor author = ELogAuthor.HCW;
					string message = "子弹Delay为负数！";
					ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("Bullet", this.BulletInfo.BulletRowName);
					instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
				}
				if (this.BulletInfo.LiveTime >= bulletDataChild.Delay * (float)Singleton<TimeUtil>.Instance.InverseMillisecond + (float)this.ChildInfo.HaveSummonedBulletNumber[num2] * bulletDataChild.Interval * (float)Singleton<TimeUtil>.Instance.InverseMillisecond)
				{
					List<int> haveSummonedBulletNumber = this.ChildInfo.HaveSummonedBulletNumber;
					int index = num2;
					int num3 = haveSummonedBulletNumber[index];
					haveSummonedBulletNumber[index] = num3 + 1;
					HashSet<string> parentIds = BulletUtil.CollectParentsId(this.BulletInfo);
					BulletController instance2 = ControllerBase<BulletController>.Instance;
					Entity attacker = this.BulletInfo.Attacker;
					string bulletRowName = bulletDataChild.RowName.ToString();
					FTransformDouble? initialTransform = new FTransformDouble?(this.BulletInfo.ActorComponent.ActorTransform);
					BulletController.BulletCreateParams bulletCreateParams = new BulletController.BulletCreateParams();
					bulletCreateParams.SkillId = this.BulletInfo.BulletInitParams.SkillId;
					bulletCreateParams.SkillContextId = this.BulletInfo.BulletInitParams.SkillContextId;
					Entity target = this.BulletInfo.Target;
					bulletCreateParams.ParentTargetId = ((target != null) ? new int?(target.Id) : null);
					bulletCreateParams.ParentId = this.BulletInfo.Entity.Id;
					bulletCreateParams.BattleContext = this.BulletInfo.BulletInitParams.BattleContext;
					bulletCreateParams.ParentIds = parentIds;
					BulletEntity bulletEntity = instance2.CreateBulletCustomTarget(attacker, bulletRowName, initialTransform, bulletCreateParams, this.BulletInfo.ContextId, EBulletCreateSource.Others);
					if (bulletEntity == null)
					{
						if (bulletDataChild.BreakOnFail)
						{
							return;
						}
					}
					else
					{
						BulletUtil.ProcessHandOverEffectToSon(this.BulletInfo, bulletEntity);
					}
				}
			}
		}
	}

	// Token: 0x0400B427 RID: 46119
	[Nullable(2)]
	public BulletChildInfo ChildInfo;

	// Token: 0x0400B428 RID: 46120
	[Nullable(new byte[]
	{
		2,
		1
	})]
	private BulletDataChild[] ChildBulletData;
}
