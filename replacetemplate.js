(function () {
    S('.replace-template button').on('click', () => {
        S.ajax({
            url: '/SaberReplaceTemplate',
            complete: () => {
                alert('Template website replaced successfully');
            },
            error: () => { alert('An error occurred while trying to replace the template website');}
        });
    });
})();