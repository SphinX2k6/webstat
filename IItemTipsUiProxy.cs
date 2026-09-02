using System;
using Cysharp.Threading.Tasks;

// Token: 0x02002082 RID: 8322
public interface IItemTipsUiProxy
{
	// Token: 0x0600FD89 RID: 64905
	void SetActive(bool visibility);

	// Token: 0x0600FD8A RID: 64906
	UniTask PlayCloseSequence();
}
