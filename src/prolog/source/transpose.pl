transpose(Ms, Ts) :-
        %must_be(list(list), Ms),
        (   Ms = [] -> Ts = []
        ;   Ms = [F|_],
            transpose(F, Ms, Ts)
        ).

transpose([], _, []).
transpose([_|Rs], Ms, [Ts|Tss]) :-
        lists_firsts_rests(Ms, Ts, Ms1),
        transpose(Rs, Ms1, Tss).

lists_firsts_rests([], [], []).
lists_firsts_rests([[F|Os]|Rest], [F|Fs], [Os|Oss]) :-
        lists_firsts_rests(Rest, Fs, Oss).